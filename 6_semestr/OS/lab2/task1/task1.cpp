#include<cstdlib>
//#include<string>
#include<iostream>
#include<unistd.h>
#include<ctime>
#include<string.h>
#include<sys/wait.h>
#include<sys/errno.h>

using namespace std;

#define PROG1 "./home/orangenal/Documents/labs/6_semestr/OS/lab2/progs/prog1"
#define PROG2 "./home/orangenal/Documents/labs/6_semestr/OS/lab2/progs/prog2"

void error();
int execute(int);
int firstProcess();
int secondProcess();
int thirdProcess();
int fourthProcess();
string arrows(int);

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
            ret_code = firstProcess();
            break;
        case 2:
            ret_code = secondProcess();
            break;
        case 3:
            ret_code = thirdProcess();
            break;
        case 4:
            ret_code = fourthProcess();
            break;
        default:
            break;
    }
    return ret_code;
}

int firstProcess(){
    time_t current_time = time(NULL);
    cout << arrows(1) << "Первый процесс (1), PID: " << getpid() << " PPID: " << getppid() << ". Текущее время: " << ctime(&current_time);
    cout << arrows(1) << "Запускаю программу \"prog1\" (собственная)\n";
    cout << arrows(1) << "Вывод запущенной программы:\n";

    char * const args[3] = {"prog1", "Аргумент1", "Аргумент2"};
    execv(PROG1, args);

    char* buf = new char[100];
    cout << arrows(2) << "SecondProcess::execl::ERROR::" << strerror_r(errno, buf, 100) << "\n";

    current_time = time(NULL);
    cout << arrows(1) << "Процесс(2) завершился! Текущее время: " << ctime(&current_time);

    return EXIT_SUCCESS;
}

int secondProcess(){
    time_t current_time = time(NULL);
    cout << arrows(1) << "Второй процесс (2), PID: " << getpid() << " PPID: " << getppid() << ". Текущее время: " << ctime(&current_time);
    cout << arrows(1) << "Запускаю программу \"PROG2\" (собственная)\n";
    cout << arrows(1) << "Вывод запущенной программы:\n";

    char * const args[3] = {"prog2", "Аргумент1", "Аргумент2"};
    execv(PROG2, args);

    current_time = time(NULL);
    cout << arrows(1) << "Процесс(2) завершился! Текущее время: " << ctime(&current_time);

    return EXIT_SUCCESS;
}

int thirdProcess(){
    time_t current_time = time(NULL);
    cout << arrows(1) << "Третий процесс (3), PID: " << getpid() << " PPID: " << getppid() << ". Текущее время: " << ctime(&current_time);
    cout << arrows(1) << "Запускаю программу \"prog1\" (собственная)\n";
    cout << arrows(1) << "Вывод запущенной программы:\n";

    char * const args[3] = {"first", "Аргумент1", "Аргумент2"};
    execv(PROG1, args);

    current_time = time(NULL);
    cout << arrows(1) << "Процесс(3) завершился! Текущее время: " << ctime(&current_time);

    return EXIT_SUCCESS;
}

int fourthProcess(){
    time_t current_time = time(NULL);
    cout << arrows(1) << "Четвёртый процесс (4), PID: " << getpid() << " PPID: " << getppid() << ". Текущее время: " << ctime(&current_time);
    cout << arrows(1) << "Запускаю программу \"prog1\" (собственная)\n";
    cout << arrows(1) << "Вывод запущенной программы:\n";

    char * const args[3] = {"first", "Аргумент1", "Аргумент2"};
    execv(PROG1, args);

    current_time = time(NULL);
    cout << arrows(1) << "Процесс(4) завершился! Текущее время: " << ctime(&current_time);

    return EXIT_SUCCESS;
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

string arrows(int n)
{
    string res = "";
    for(int i = 0; i < n; i++)
        res += ">>>";
    return res;
}


