#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <sys/time.h>
#include <sys/types.h>
#include <unistd.h>
#include <pthread.h>
#include <dirent.h>
#include <string.h>
#include <sys/errno.h> 
#include <sys/wait.h> 
 
char** files; // массив с именами файлов
 
void* create_file(void *arg) // поток создания файла
{
    int* tmp =(int*) arg; // индекс указывающий на имя файла
    int ind = *tmp;
    int rec_error;
    free (tmp);
 
    FILE* fl;
    long unsigned int PID;
    int pid, ppid, num;
    long unsigned int len, i = 0;
    char buf;
    time_t vremya= time(NULL);
    num = ind*2 + 1; // номер потока
    len = rand() %10000 + 3; // количество символов в файле
    len +=2;
    PID = pthread_self(); // ThreadID
    pid = getpid(); // PID
    ppid = getppid(); // PPID
    sprintf(files[ind], "%s/%lu%s", getenv("PWD"), PID, ".txt"); // имя файла
    //fl = fopen(files[ind], "w");// создаем файл
    if( fl = fopen(files[ind], "w")) // если файл создан
    {
        while( i!=len) // пока не запишем все символы
        {
            if( i % 2 ) buf = '0';
            else buf = '1';
            fputc(buf, fl);
            i++;
        } 
        if( fclose(fl) == EOF) printf("Fclose Error"); // закрываем файл
    }
    // выводим на экран информацию о потоке и файле
    printf("\nWriting...\nThread #%i\n\tThreadID: %lu\n\tPID: %i\n\tPPID: %i\n\tTimeDate: %s\tFileName: %s\n\tLength: %lu\n\tErr: %d\n", num, PID, pid, ppid, ctime(&vremya), files[ind], len, errno);
    pthread_exit(NULL);
}
 
void* read_file(void *arg) // поток читающий файл
{
    int* tmp =(int*) arg; // индекс указывающий на имя файла
    int ind = *tmp;
    free (tmp);
    
    FILE* fl;
    long unsigned int PID;
    int i = 0, pid, ppid, num;
    long int len = 0;
    //char t[32];
    char buf[256];
    time_t vremya= time(NULL);
    num = ind*2 + 2;   // номер потока
    PID = pthread_self(); // ThreadID
    pid = getpid(); // PID
    ppid = getppid(); // PPID
    //fl = fopen(files[ind], "r"); // открываем файл для чтения
    if( fl = fopen(files[ind], "r")) // если файл открылся
    {
        strcpy(buf, files[ind]); // считываем название файла
        while( i!=EOF ) // пока не достигнем конца файла
        {
            i = fgetc(fl); // считываем посимвольно
            if( i!=EOF ) len++; // счетчик символов
        }
        if( fclose(fl) == EOF) printf("Fclose Error"); // закрываем файл
    }
    // выводим результаты работы
    int err = errno;
    printf("\nReading...\nThread #%i\n\tThreadID: %lu\n\tPID: %i\n\tPPID: %i\n\tTimeDate: %s\tFileName: %s\n\tLength: %lu\n\tErr: %d\n", num, PID, pid, ppid, ctime(&vremya), buf, len, err);
    if (err != 0)
    perror("Reading file error: ");
    printf("\n");
    pthread_exit(NULL);
}
 
// запускаем приложение
int main(int argc, char* argv[])
{
int i, qnt, res, tmp;
    FILE* fl;
    pthread_t* ws;
    pthread_t* rs;
    srandom(time(NULL));
    if( argc == 2 ) qnt = atoi(argv[argc-1]); // выбираем количество пар потоков из командной строки
    else qnt = 0;
    //if( qnt ) // если в командной строке прописано количество пар потоков
    //{
        ws = new pthread_t[qnt]; // создаем указатели на потоки записи
        rs = new pthread_t[qnt]; // создаем указатели на потоки чтения
        files = new char*[qnt]; // создаем массив имен файлов
        for(i=0; i<qnt;i++)
        {
            files[i] = new char[256]; // инициализируем строку имени файла
            res = pthread_create(&ws[i], NULL, create_file, new int(i)); // запускаем нечетный поток
            if (res != 0) // проверка на успех
            {
                perror("creation failed");
                exit(EXIT_FAILURE);
            }
            res = pthread_create(&rs[i], NULL, read_file, new int(i)); // запускаем четный поток
            if (res != 0) // проверяем
            {
                perror("Thread creation failed");
                exit(EXIT_FAILURE);
            }
        }
         int er=-1;
        // проверяем завершение потоков, а так же удаляем файлы и очищаем память
        for(i=qnt-1; i>=0; i--)
        {
            tmp = i*2+1;
            res = pthread_join(ws[i], NULL);
            //if (res == 0) perror("Процесс успешно завершился! ");
if (res!=0)
    perror ("\nProgram Error: ");
  else perror("Процесс успешно завершился! ");  //{er = 0;}// printf("Picked up a thread #%i\n", tmp);
            //else perror("pthread_join failed");
            tmp = i*2+2;
            res = pthread_join(rs[i], NULL);
if (res!=0)
    perror ("\nProgram Error: ");
  else perror("Процесс успешно завершился! "); ;


            //if (res == 0)//{er = 0;} //printf("Picked up a thread #%i\n", tmp);
            //else perror("pthread_join failed");
            fl = fopen(files[i], "r");
            if( fl )
            {
                fclose(fl);
                remove(files[i]);
            }
            free (files[i]);
        }
 
        free (files);
        free (ws);
        free (rs);
    //}
 
    printf("All done\n");
    exit(EXIT_SUCCESS);
}
