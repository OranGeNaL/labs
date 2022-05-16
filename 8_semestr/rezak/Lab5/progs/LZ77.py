import sys

sys.setrecursionlimit(15000)


inp = input("Введите сообщение: ").upper()
outp = str()
code = str()

def depth(output_ind_start, output_ind_end):
    global inp
    global outp
    global code
    if inp[output_ind_start: output_ind_end] == '':
        return

    if inp[output_ind_start: output_ind_end] in outp and len(inp[output_ind_start: output_ind_end]) > 2:
        code += "(" + str(outp.find(inp[output_ind_start: output_ind_end]) - output_ind_start) + ":" + str(output_ind_end - output_ind_start) + ")"
        outp += inp[output_ind_start: output_ind_end]
        depth(output_ind_end, len(inp))
    else:
        if output_ind_start == output_ind_end - 1:
            code += inp[output_ind_start:output_ind_start + 1]
            outp += inp[output_ind_start:output_ind_start + 1]
            if output_ind_start + 1 < len(inp):
                depth(output_ind_start + 1, len(inp))
        else:
            depth(output_ind_start, output_ind_end - 1)


depth(0, len(inp))
print("Зашифрованное сообщение: " + code)
