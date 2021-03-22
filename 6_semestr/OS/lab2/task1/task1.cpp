#include <stdio.h>
#include <iostream>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/errno.h> 
#include <sys/wait.h> 
#include <time.h>
#include <errno.h>

using namespace std;

#define TEST "./ex2"
#define TEST1 "./ex3"

void error();
int execute(int);

int main(int argc, char **argv) {

    if (argc != 5) {
        cout << "Программе необходимо 4 аргумента!\n";
        return EXIT_FAILURE;
    }

    cout << "Начало родительского процесса\n";

    int pid(-1);
    int status;

    for (int i = 1; i <= 4; ++i) {
        pid = fork();

        if (pid == 0) {
            return execute(atoi(argv[i]));
        } else {
            cout << "Процесс создан\n";
            int ch_pid = wait(&status);
            cout << "Процесс PID " << ch_pid << " завершился с кодом " << status << "\n\n";
        }
    }

    cout << "THE END\n";
    return EXIT_SUCCESS;
}

int execute(int n){
    int ret_code;

    switch (n) {
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
        default:

            break;
    }
}

void error()
{
	switch(errno)
	{
	case EDOM:
	printf("errno = %d ошибка области допустимых значений",errno);
break;
	case EILSEQ:
	printf("errno = %d ошибочная последовательность байтов",errno);
break;
	case ERANGE:
	printf("errno = %d результат слишком велик",errno);
break;
	case EACCES:
	printf("errno = %d доступ к файлу запрещен",errno);
break;
	case ENOEXEC:
	printf("errno = %d заголовок файла не распознается",errno);
break;
	case ENOENT:
	printf("errno = %d файл не найден",errno);
	default:
break;
	
	}
}


