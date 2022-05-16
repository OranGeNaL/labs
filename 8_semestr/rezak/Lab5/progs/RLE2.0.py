import re
text = input("Введите сообщение для зашифровки: ")

def func(p): return len(p)

def sort_result(p): return p[1]

result = list()

def find_chains(text):
    combinations = list()
    for i in range(0, len(text)):
        for j in range(1, len(text) + 1):
            if i < j:
                combinations.append(text[i:j])

    legal_combo = list()
    for combination in combinations:
        if combination[0] * len(combination) == combination and len(combination) > 1:
            legal_combo.append(combination)

    if legal_combo == list():
        return

    max_combo = max(legal_combo, key=func)

    ind_max_combo = text.find(max_combo)

    result.append([max_combo, ind_max_combo, len(max_combo)])
    find_chains(text[0:ind_max_combo] + text[ind_max_combo + len(max_combo):])

def RLE(text):
    global result
    find_chains(text)

    result = sorted(result, key=sort_result)

    for element in result:
        text = text.replace(element[0], str(element[2]) + element[0][0], 1)

    lst = re.split('0|1|2|3|4|5|6|7|8|9', text)

    for i, element in enumerate(lst[1:]):
        lst[i+1] = element[1:]

    lst = sorted(lst, reverse=True, key=len)

    lst = [x for x in lst if x]

    for element in lst:
        if len(element) != 1:
            text = text.replace(element, str(-1 * len(element)) + element, 1)
        else:
            text = text.replace(element, str(len(element)) + element, 1)

    return text

code = RLE(text)
print("Зашифрованное сообщение: ",code)
