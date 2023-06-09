#include "stdio.h"
#include "stdlib.h"
#include "time.h"
#include "limits.h"

int main() 
{
	srand(time(NULL));

	// берём от пользователя количество элементов в массиве 
	printf("Введите размер массива: ");
	int arrsize = 0;
	scanf("%d", &arrsize);

	// собственно, сам массив
	int array[arrsize];

	// заполняем массив
	for (int i = 0; i < arrsize; i++)
	{
		array[i] = rand()%100 - 50;
	}

	// выводим массив в формате [1, 2, 3, ..., n]
	printf("[");
	for (int i = 0; i < arrsize; i++)
	{
		printf("%d, ", array[i]);
	}
	printf("]\n");

	// находим максимальный по модулю элемент массива
	// берём INT_MAX из прошлого задания, чтобь задать первоначальный максимум с самого минимума, иначе могут быть проблемы
	int absmax = INT_MIN;
	for (int i = 0; i < arrsize; i++)
	{
		// функция abs убирает знак, то есть даёт модуль числа
		// условие проверяет, если модуль проверяемого элемента массива больше, чем прошлый максимум, то выводит его
		if (abs(array[i]) > absmax)
		{
			absmax = array[i];
		}
	}
	printf("Максимальное по модулю значение элемента: %d\n", absmax);

	// находим минимальный по значению элемент массива
	// берём INT_MIN из прошлого задания, чтобы задать первоначальный минимум самым большим возможным числом, иначе могут быть проблемы
	int min = INT_MAX;
	for (int i = 0; i < arrsize; i++)
	{
		// функция abs убирает знак, то есть даёт модуль числа
		// условие проверяет, если модуль проверяемого элемента массива больше, чем прошлый максимум, то выводит его
		if (array[i] < min)
		{
			min = array[i];
		}
	}
	printf("Минимальный по значению элемент: %d\n", min);

	// среднее арифметическое
	int am = 0; // am от английского arithmetic mean (среднее арифметическое)
	for (int i = 0; i < arrsize; i++)
	{
		am += array[i];
	}
	am = am / arrsize;
	printf("Среднее арифметическое: %d\n", am);

	// количество элементов, значение которых больше среднего арифметического
	int count = 0;
	for (int i = 0; i < arrsize; i++)
	{
		if (array[i] > am)
		{
			count++;
		}
	}
	printf("Количество элементов, значение которых больше среднего арифметического: %d\n", count);

	return 0;
}