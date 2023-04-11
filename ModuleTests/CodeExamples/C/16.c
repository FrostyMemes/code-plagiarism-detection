//
//  main.c
//  pz_8
//
//  Created by Юра Елизаров on 15.11.2022.
//  Реализовать программу, которая делает следующее:
//  1) с помощью генератора случайных чисел задаёт значения элементов одномерного
//  целочисленного массива постоянного размера (размерность массива задаётся
//  пользователем);
//  2) находит максимальный по модулю элемент массива;
//  3) находит минимальный по значению элемент массива;
//  4) находит среднее арифметическое значений элементов массива;
//  5) подсчитывает количество элементов массива, значение которых больше среднего
//  арифметического.
//

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>

int main(int argc, const char * argv[]) {
//  инициализация переменных
    int arr[100] = {};
    int length;
    srand(time(NULL));
    int min_value = 101;
    int max_value = 0;
    int sum = 0;
    int count_more_average = 0;
    
//  Ввоод длины массива
    printf("Введите длинну массива (максимум 100) \n");

    while (scanf("%d", &length) != 1 || length <= 0 || length > 100) {
        fflush(stdin);
        printf("Введите длинну массива \n");
    }
    
//  Заполянем массив рандомными переменными от -50 до 100, ищем минимальное значени, максимальное по модулю
//  и пополняем сумму всех элементов для среднего арифметического
    for (int i = 0; i < length; i++) {
        arr[i] = rand()%150 - 50;
        min_value = arr[i] < min_value ? arr[i] : min_value;
        max_value = abs(arr[i]) > max_value ? abs(arr[i]) : max_value;
        sum += arr[i];
    }
    
//  находим среднее арифметическое
    float average = sum / (float)length;
    
//  находим количество элементов больше среднего арифметического
    for (int i = 0; i < length; i++) {
        if (arr[i] > average) {
            count_more_average++;
        }
    }
    
//  Вывод элементов
    for (int i = 0; i < length; i++) {
        if (i == 0) {
            printf("%d", arr[i]);
        } else {
            printf(", %d", arr[i]);
        }
    }
    printf("\n");
    printf("Mаксимальный по модулю элемент массива: %d \n", max_value);
    printf("Минимальный по значению элемент массива: %d \n", min_value);
    printf("Среднее арифметическое элементов массива: %f \n", average);
    printf("Количество элементов массива, значение которых больше среднего арифметического: %d \n\n", count_more_average);
    
//  считаем количество одинаковых цифр
    int count_numbers[150] = {};
    for (int i = 0; i < length; i++) {
        count_numbers[arr[i] + 50]++;
    }
    
//  Подсчет максимальной длины последовательности одинаковых цифр
    int current_number = 0;
    int current_length_subsequence = 0;
    int max_length_subsequence = 0;
    int max_subsequence_number = 0;
    
    for (int i = 0; i < length; i++) {
        if (arr[i] != current_number) {
            if (current_length_subsequence > max_length_subsequence) {
                max_length_subsequence = current_length_subsequence;
                max_subsequence_number = current_number;
            }
            current_number = arr[i];
            current_length_subsequence = 0;
        } else {
            current_length_subsequence++;
        }
    }
    
    printf("Number: %d, Length: %d \n\n", max_subsequence_number, max_length_subsequence);
    
//  Вывод цифр и их количество в массиве
    int printed_number = 0;
    for (int i = 0; i < 150; i++) {
        if (count_numbers[i] > 0) {
            if (printed_number == 0) {
                printf("%d: %d", i - 50, count_numbers[i]);
                printed_number++;
            } else {
                printf(", %d: %d", i - 50, count_numbers[i]);
            }
        }
    }
    printf("\n");
    
    return 0;
}
