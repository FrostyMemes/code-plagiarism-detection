#include <stdio.h>  		// ���������� ������������ ���� stdio.h
#include<locale.h>  
#include<stdlib.h>
#include<time.h>
int main(void)                  
{  
int chislo1,chislo2,prov;
int min,max,i,j,kolvo,kolvobol;
float summa;  //chislo - ���������� ��� ����� �������� �������������        
setlocale(LC_ALL,"Russian");	//������������
do{               
    printf("������� ���-�� ��������\n");
prov = scanf("%i", &chislo2);	//�������� �� �����
fflush(stdin);					//������� �������������
}while ( prov!=1 || (chislo2>100) || (chislo2<1));  //���� ��� ����� � ���������� �� 1 �� 9 �� ��������

srand(time(NULL)); //������� ��� ��������� ��������� �����
int mass[chislo2];	
min=101;
max=0;
kolvobol=0;

	for (j = 1; j <= chislo2; j++) 
	{
		mass[j]= rand()%101-50;	//����������� ���������� ����� � ������ � ���������� �� -50 �� 50 
		summa=summa+mass[j];
		if(mass[j]<min) 		//���������� ������������ �����
			{
			min=mass[j];
			}
			
		if(mass[j]>max)			//���������� ������������� ����� �� ������ ���� ����� �������������
			{
			max=mass[j];
			i=j;
			}	
		if(mass[j]*(-1)>max)	//���������� ������������� ����� �� ������ ���� ����� �������������
			{
			max=mass[j];
			i=j;
			}				
	}


	for (j = 1; j <= chislo2; j++) //���� ��� ������ �������
	{
	printf("%d",mass[j]);			// ����� ������� �� �����
		if (j!=chislo2)				// ������� ��� ������� ��� �� ��� �� ��������� � �����
		{
		printf(",");
		}
		if(mass[j]>summa/chislo2)
		{
		kolvobol++;
		}
	}	
printf("\n");
printf("������������ ������� %d \n",mass[i]);
printf("����������� ������� %d\n",min);
printf("������� �������������� �������� ��������� ������� %.1f\n",summa/chislo2);
printf("���������� ��������� �������, �������� ������� ������ ����������������������� %d\n",kolvobol);
return 0;	
}                               