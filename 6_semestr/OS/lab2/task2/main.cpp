#include <cstdio>
#include <cstdlib>
#include <ctime>
#include <sys/types.h>
#include <unistd.h>
#include <pthread.h>
#include <cerrno>
#include <iostream>

using namespace std;

char **files; // массив с именами файлов
pthread_t *write_threads;   //указатель на массив потоков создания фалов

void *create_file(void *arg) // поток создания файла
{
    int ind(*(int *) arg);// индекс указывающий на имя файла
    long unsigned int PID = pthread_self();
    int pid = getpid();
    int ppid = getppid();
    long unsigned int length(rand() % 100000);
    time_t _time = time(nullptr);
    int *creation_status = new int(EXIT_SUCCESS); //статус завершения этого потока

    sprintf(files[ind], "%s/%lu%s", getenv("PWD"), PID, ".txt"); // имя файла
    FILE *fl = fopen(files[ind], "w");

    if (fl) {
        for (int i = 0; i < length; ++i) {
            char symbol(rand() % 40 + 40);
            fputc(symbol, fl);
        }

        if (fclose(fl) != 0) {
            cout << "FILE_CREATE::fclose::Невозможно закрыть файл (" << files[ind] << ")\n";
            *creation_status = EXIT_FAILURE;
            pthread_exit((void *) creation_status);
        }
    } else {
        cout << "FILE_CREATE::fopen::Невозможно открыть файл (" << files[ind] << ")\n";
        *creation_status = EXIT_FAILURE;
        pthread_exit((void *) creation_status);
    }

    // выводим на экран информацию о потоке и файле
    printf("\nЗапись...\nПоток #%i\n\tID Потока: %lu\n\tPID: %i\n\tPPID: %i\n\tВремя: %s\tИмя файла: %s\n\tДлина: %lu\n\tErr: %d\n",
           (ind + 1), PID, pid, ppid, ctime(&_time), files[ind], length, errno);

    pthread_exit((void *) creation_status);
}

void *read_file(void *arg) // поток читающий файл
{
    int ind(*(int *) arg);// индекс указывающий на имя файла

    long unsigned int PID = pthread_self();
    int pid = getpid();
    int ppid = getppid();
    long unsigned int length = 0;
    time_t _time = time(nullptr);
    int *read_status = new int(EXIT_SUCCESS); //статус завершения этого потока

    void *file_create_ret_value(nullptr);
    pthread_join(write_threads[ind], &file_create_ret_value);

    if (*(int *) file_create_ret_value != EXIT_SUCCESS) {
        *read_status = EXIT_FAILURE;
        pthread_exit((void *) read_status);
    }

    FILE *fl = fopen(files[ind], "r");

    if (fl) {
        while (fgetc(fl) != EOF) {
            ++length;
        }

        if (fclose(fl) != 0) {
            cout << "FILE_READ::fclose::Невозможно закрыть файл (" << files[ind] << ")\n";
            *read_status = EXIT_FAILURE;
            pthread_exit((void *) read_status);
        }
    } else {
        cout << "FILE_READ::fopen::Невозможно открыть файл (" << files[ind] << ")\n";
        *read_status = EXIT_FAILURE;
        pthread_exit((void *) read_status);
    }

    printf("\nЧтение...\nПроцесс #%i\n\tID Процесса: %lu\n\tPID: %i\n\tPPID: %i\n\tВремя: %s\tИмя файла: %s\n\tДлина: %lu\n\tErr: %d\n",
           (ind + 1), PID, pid, ppid, ctime(&_time), files[ind], length, errno);
    pthread_exit((void *) read_status);
}

int main(int argc, char *argv[]) {

    if (argc != 2) {
        cout << "Using: \n";
        cout << "./main [n]\n";
        return EXIT_FAILURE;
    }

    if (strtol(argv[1], nullptr, 10) <= 1) {
        cout << "Некорректное количество пар!\n";
        return EXIT_FAILURE;
    }

    void *ret_value; //значение, возвращаемое потоком
    unsigned int pairs_amount(strtol(argv[1], nullptr, 10));   //количество пар потоков
    srandom(time(nullptr));

    write_threads = new pthread_t[pairs_amount];
    auto *read_threads = new pthread_t[pairs_amount]; //массив потоков чтения файлов
    files = new char *[pairs_amount];
    for (int i = 0; i < pairs_amount; ++i) {         //создания потоков создания файлов
        files[i] = new char[256];

        if (pthread_create(&write_threads[i], nullptr, create_file, new int(i)) != 0) {
            cout << "PTHREAD_CREATE::ошибка создания потока создания файла\n";
            return EXIT_FAILURE;
        }
    }

    for (int i = 0; i < pairs_amount; i++) {         //создание потоков чтения фалов

        if (pthread_create(&read_threads[i], nullptr, read_file, new int(i)) != 0) {
            cout << "PTHREAD_CREATE::ошибка создания потока чтения файла\n";
            return EXIT_FAILURE;
        }

        pthread_join(read_threads[i], &ret_value);
        if (*(int *) ret_value != EXIT_SUCCESS) {
            cout << "PAIR #" << i + 1 << "::failed\n";
        }
    }
    
    
// проверяем завершение потоков, а так же удаляем файлы и очищаем память
    
    for (unsigned int i = 0; i < pairs_amount; i++) {
        FILE *fl = fopen(files[i], "r");
        if (fl) {
            fclose(fl);
            remove(files[i]);
            free(files[i]);
        }
    }
    
    free(files);
    free(write_threads);
    free(read_threads);
    return EXIT_SUCCESS;
}
