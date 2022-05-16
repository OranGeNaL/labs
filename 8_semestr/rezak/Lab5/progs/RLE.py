def count_overlapping_substrings(haystack, needle):
    count = 0
    i = -1
    while True:
        i = haystack.find(needle, i+1)
        #print(needle + " " + str(i))
        #input()
        if i == -1:
            return count
        i += len(needle) - 1
        count += 1


def find_index_start_substring(haystack, needle):
    count = 0
    i = -1
    while True:
        prev_i = i
        i = haystack.find(needle, i+1)
        #print(needle + " " + str(i))
        #input()
        if i == -1:
            return prev_i - count * (len(needle)) + 1
        i += len(needle) - 1
        count += 1


result = []
def RLE(text):
    # Поиск комбинаций
    combinations = []
    #print(text[0:1])
    for i in range(0, len(text)):
        for j in range(1, len(text) + 1):
            if i < j:
                count = count_overlapping_substrings(text, text[i:j])
                #print(text[i:j])
                if [text[i:j], count] not in combinations:
                    combinations.append([text[i:j], count])
    #print("combinations: " + str(len(combinations)))
    if (len(combinations) == 0):
        return
    #  Нахождение максимума комбинаций и комбинации с этим максимумом
    sorted_combination = list()
    mx = 0
    for i in combinations:
        if mx <= i[1]:
            mx = i[1]
    for i in combinations:
        if i[1] == mx:
            sorted_combination.append(list(i))
    #print(sorted_combination)
    # Отбор по максимальному количеству символов
    mx_let = len(sorted_combination[0][0])
    value = list()
    for val in sorted_combination:
        if mx_let <= len(val[0]):

            mx_let = len(val[0])
            value = val
    # Запись результата и вычисление остатка рекурсией
    result.append(value)
    ind_start = find_index_start_substring(text, value[0])
    #print(result)
    #print(text[0: value[2]] + text[(value[1]+value[2]) * len(value[0]): len(text)])
    #input()
    RLE(text[0: ind_start] + text[(value[1]+ind_start) * len(value[0]): len(text)])

def main():
    source_text = input("Введите сообщение: ")
    RLE(source_text)


    unsorted_result = list()
    indeces_list = list()
    for element_ind in range(0, len(result)):
        start_ind = find_index_start_substring(source_text, result[element_ind][0])
        result[element_ind].append(start_ind)
        if len(result[element_ind][0]) > 1:
            result[element_ind][1] = -result[element_ind][1]

        indeces_list.append(find_index_start_substring(source_text, result[element_ind][0]))


    encode = ""
    indeces_list = sorted(indeces_list)
    for ind in indeces_list:
        for element in result:
            if element[2] == ind:
                if element[1] < 0:
                    encode += str(len(element[0]) * element[1]) + element[0] * abs(element[1])
                else:
                    encode += str(element[1]) + element[0]
                break

    print("Зашифрованное сообщение: " + encode)
main()
