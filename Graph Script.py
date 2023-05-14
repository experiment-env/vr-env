import matplotlib.pyplot as plt

# Example data
# MapID;NotificationType;NotificationColor;Warning;Speed;CorrentAnswer;Answer;Time
data = '''001;Head;Flash;true;10;Yes;Yes;4.9098100077970654
001;Head;Flash;false;10;Yes;No;4.724963070280283
001;Head;Flash;true;10;Yes;Yes;4.6033109955500455
001;Head;Bright;false;20;Yes;No;4.734782560046433
001;Hand;Flash;true;10;Yes;Yes;5.01389240296449
001;Hand;Bright;false;10;Yes;No;4.989054592241313
001;Hand;Flash;true;20;Yes;Yes;4.596801511043872
001;Head;Bright;true;10;Yes;Yes;5.352550482230617
001;Head;Flash;false;20;Yes;Yes;5.165027411958039
001;Head;Flash;true;10;Yes;Yes;4.967797996344776'''

rows = data.split("\n")
parsed_data = [row.split(";") for row in rows]

notification_types = [row[1] for row in parsed_data]
notification_colors = [row[2] for row in parsed_data]
warnings = [row[3] for row in parsed_data]
speeds = [int(row[4]) for row in parsed_data]
correct_answers = [row[5] for row in parsed_data]
answers = [row[6] for row in parsed_data]
times = [float(row[7]) for row in parsed_data]

def group_data(variable, times, correct_answers, answers):
    grouped_data = {}
    grouped_accuracy = {}
    for var, time, correct_answer, answer in zip(variable, times, correct_answers, answers):
        if var not in grouped_data:
            grouped_data[var] = []
            grouped_accuracy[var] = [0, 0]  # [correct, total]
        grouped_data[var].append(time)
        grouped_accuracy[var][1] += 1  # Increase total count
        if correct_answer == answer:  # If the answer is correct
            grouped_accuracy[var][0] += 1  # Increase correct count
    for key in grouped_accuracy:
        grouped_accuracy[key] = grouped_accuracy[key][0] / grouped_accuracy[key][1]  # Calculate accuracy
    return grouped_data, grouped_accuracy

def create_boxplot(grouped_data, grouped_accuracy, title):
    labels, data = zip(*grouped_data.items())
    accuracy = [grouped_accuracy[key]*100 for key in labels]
    plt.rcParams["axes.titlepad"] = 30.0
    plt.rcParams['axes.titleweight'] = 'bold'
    fig, ax = plt.subplots()
    plt.grid()
    ax.boxplot(data)
    ax.set_xticklabels(labels)
    ax.set_title(title)
    ax.set_ylabel('Time')
    for i in range(len(labels)):
        plt.text(i+1, 1.02, f"Accuracy: {accuracy[i]:.2f}%", horizontalalignment='center', transform=ax.get_xaxis_transform())
    plt.show()

notification_type_data, notification_type_accuracy = group_data(notification_types, times, correct_answers, answers)
create_boxplot(notification_type_data, notification_type_accuracy, 'Notification Position')

notification_color_data, notification_color_accuracy = group_data(notification_colors, times, correct_answers, answers)
create_boxplot(notification_color_data, notification_color_accuracy, 'Notification Color')

warning_data, warning_accuracy = group_data(warnings, times, correct_answers, answers)
create_boxplot(warning_data, warning_accuracy, 'Warning on Cars')

speed_data, speed_accuracy = group_data(speeds, times, correct_answers, answers)
create_boxplot(speed_data, speed_accuracy, 'Speed')
