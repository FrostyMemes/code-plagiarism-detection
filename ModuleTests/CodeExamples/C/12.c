#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <math.h>

int main(void) {
    system("chcp 65001>null"); // Изменение кодировки консоли на UTF-8
    srand(time(NULL)); // Установка исходного числа в случайной последовательности

    int array_length = 0;
    printf("Введите целое число, чтобы задать размер массива: ");
    scanf("%d", &array_length);

    if (array_length <= 0) { // Массив длиной меньше 1 не имеет смысла
        printf("Размер массива должен быть не менее 1");
        return 0;
    }

    int arr[array_length]; // Целочисленный массив длиной array_length
    int abs_max_idx = 0; // Индекс элемента максимального по модулю
    int min_idx = 0; // Индекс элемента минимального по значению
    int arr_sum = 0; // Сумма элементов массива (для нахождения среднего арифметического)
    for (int i = 0; i < array_length; i++) {
        arr[i] = rand() - RAND_MAX / 2; // Чтобы присутсвовали отрицательные значения вычитаем половину максимального случайного значения
        arr_sum += arr[i];
        if (abs(arr[i]) > abs(arr[abs_max_idx])) abs_max_idx = i;
        if (arr[i] < arr[min_idx]) min_idx = i;
    }
    float arr_avg = arr_sum / (float)array_length; // Вычисление среднего арифметического

    int greater_avg_count = 0;
    for (int i = 0; i < array_length; i++) { // Поиск количества элементов, которые больше среднего арифметического
        if (arr[i] > arr_avg) greater_avg_count++;
    }

    printf("Массив: %d", arr[0]);
    for (int i = 1; i < array_length; i++) {
        printf(", %d", arr[i]);
    }
    printf("\n");
    printf("Максимальный по модулю элемент массива: [индекс=%d] %d (модуль числа = %d)\n", abs_max_idx, arr[abs_max_idx], abs(arr[abs_max_idx]));
    printf("Минимальный по значению элемент массива: [индекс=%d] %d\n", min_idx, arr[min_idx]);
    printf("Среднее арифметическое элементов массива: %f\n", arr_avg);
    printf("Количество элементов массива, значение которых больше среднего арифметического: %d\n", greater_avg_count);
    return 0;
}