#include <stdlib.h>
#include <stdio.h>
#include <time.h>

int main(void){
    int size,i,max,min,k;
    float sr,sum;
    printf("размер массива: ");
    scanf("%d", &size);
    printf("\n");
    
    if(size > 0){
    int array[size];  //массив указанного пользователем размера
    srand(time(NULL));
    for (i = 0; i<size;i++){
	array[i] = rand()%201 + (-100);     //псевдослучайные элементы в промежутке [-100;100]
    }
    for (i = 0; i < size; i++){            //вывод элементов массива через запятую
        if (i == size - 1){
            printf("%d\n",array[i]);      //последний элемент без запятой
        }
        else {
            printf("%d, ",array[i]);
        }
    }
    max = -1000;                       //нахождение максимального по модулю элемента
    for (i=0;i<size;i++){
        if(abs(array[i]) > max){        //abs - функция возвращает модуль числа
            max = array[i];
        }
    }
    min = 1000;                       //нахождение минимального по значению элемента
    for (i=0;i<size;i++){
        if(array[i] < min){
            min = array[i];
        }
    }
    sum = 0;
    for (i=0;i<size;i++){
        sum = sum + array[i];      //сумма всех элементов массива
    }
    sr = sum/size;                  //среднее арифметическое
    
    int k = 0;
    for (i = 0; i<size;i++){
        if (array[i] > sr){     //кол-во элементов больше среднего арифметического
            k = k+1;
        }
    }
    
    printf("максимальный по модулю элемент массива: %d\n", max);
    printf("минимальный по значению элемент массива: %d\n", min);
    printf("cреднее арифметическое элементов массива: %.3f\n", sr);
    printf("количество элементов массива, значение которых больше среднего арифметического: %d\n",k);
    
    }
    else{
        printf("размер массива не корректный. опреации невозможны!");
    }
    
}
