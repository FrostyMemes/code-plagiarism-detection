#include <stdlib.h>
#include <stdio.h>
#include <windows.h>
#include <time.h>
#include <math.h>

int main(){

    SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

    srand(time(NULL));      //случайная генерация чисел

    int size = 0;     //переменная для задания размера массива пользователем
    int temp = 0;     //переменная для временного хранения информации

    printf("Добро пожаловать в программу!\n");
    fflush(stdout);
    printf("Введите желаемый размер целочисленного массива:");
    scanf("%d", &size);

    int *array = malloc(size * sizeof(int));    //создание массива

    printf("Создан массив размером %i\n", size);
    printf("Список элементов массива следующий:");


    for(int i = 0; i < size; i++){               //цикл для генерации и вывода чисел
        temp = rand() % 200 + (-100);
        array[i] = temp;
        if(i < size && i != size - 1){
            printf(" %i", temp);
        }
        else if(i == size - 1){
            printf(" %i", temp);
        }
    }

    int max = array[0];                  //переменная для хранения информации о наибольщем значении
    int min = array[0];                   //о наименьшем значении
    int sum = 0;                                   //о сумме значений чисел массива
    float average = 0;                             //о среднем значении чисел массива
    int counter_max = 0;                       //о количестве чисел превосходящих среднее арифметическое


    for(int i = 0; i < size; i++){           //цикл для определения наибольшего, наименьшего чисел, суммы элементов массива
        if(abs(max) < abs(array[i])){
            max = array[i];
        }

        if(min > array[i]){
            min = array[i];
        }

        sum += array[i];
    }

    average = sum / size;                    //определение ср. арифм.

    for(int i = 0; i < size; i++){           //подсчёт чисел больших ср. арифм.
        if(array[i] > average){
            counter_max++;
        }
    }
    printf("\nНаибольшее по модулю число: %i\nНаименьшее по значению число: %i\nСреднее значение: %f\nКоличество чисел больших среднего значения: %i\n", max, min, average, counter_max);
    return 0;
}
