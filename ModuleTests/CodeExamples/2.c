#include <stdlib.h>
#include <stdio.h>
#include <windows.h>
#include <time.h>
#include <math.h>

int main(){
    SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

    // установка случайной генерации чисел для каждого запуска программы
    srand(time(NULL));

    int array_size = 0;// переменная для задания размера массива пользователем
    int value_temp = 0;// переменная для временного хранения информации

    printf("Добро пожаловать в программу!\n");
    fflush(stdout);
    printf("Введите желаемый размер целочисленного массива: ");
    scanf("%d", &array_size);

    // создание динамического массива для хранения информации
    int *array = malloc(array_size * sizeof(int));

    printf("Был создан массив размером - %i\n", array_size);
    printf("Список элементов массива следующий:");

    // цикл для генерации и вывода сгенерированных чисел на экран пользователя
    for(int i = 0; i < array_size; i++){
        value_temp = rand() % 200 + (-100);
        array[i] = value_temp;
        if(i < array_size && i != array_size - 1){
            printf(" %i,", value_temp);
        }
        else if(i == array_size - 1){
            printf(" %i", value_temp);
        }
    }

    int highest_value = array[0];// переменная для хранения информации о наибольщем значении
    int lowest_value = array[0];// переменная для хранения информации о наименьшем значении
    int sum = 0;// переменная для хранения информации о сумме значений чисел массива
    float average = 0;// переменная для хранения информации о среднем значении чисел массива
    int counter_highest = 0;// переменная для хранения информации о количестве чисел превосходящих среднее арифметическое

    // цикл для определения наибольшего и наименьшего чисел, а также подсчета суммы элементов массива
    for(int i = 0; i < array_size; i++){
        if(abs(highest_value) < abs(array[i])){
            highest_value = array[i];
        }

        if(lowest_value > array[i]){
            lowest_value = array[i];
        }

        sum += array[i];
    }

    average = sum / array_size;// определение среднего арифметического

    // цикл для подсчета чисел, превосходящих среднее арифметическое
    for(int i = 0; i < array_size; i++){
        if(array[i] > average){
            counter_highest++;
        }
    }

    printf("\nРезультат выполнения программы!\nНаибольшее число в массиве по модулю: %i\nНаименьшее число в массиве по значению: %i\nСреднее значение чисел массива: %f\nСумма чисел в массиве: %i\nКоличество чисел больших среднего значения: %i\n", highest_value, lowest_value, average, sum, counter_highest);

    return 0;
}