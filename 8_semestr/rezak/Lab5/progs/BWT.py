
def BWT(text):

    assert "|" not in text
    text = text + "|"

    table = [text[i:] + text[:i] for i in range(len(text))]
    
    # print("Перебор")
    # for i in table:
    #     print(i)

    # print("Отсортированные")
    table = sorted(table)
    # for i in table:
    #     print(i)

    last_column = [row[-1:] for row in table]
    bwt = ''.join(last_column)
    return bwt


text = input("Введите сообщение: ")
print("Зашифрованное сообщение: " + BWT(text))
