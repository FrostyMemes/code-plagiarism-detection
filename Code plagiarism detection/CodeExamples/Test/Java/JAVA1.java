import java.util.*;

public class Task1 {
    public static void main(String[] args) {
        Arrays.stream(taskDistinct(new double[]{2,5,7,2,9,4,6,23,7,8,9,2,1,6,4,2,6,7}))
                .forEach(System.out::println);
    }

    public static double[] task(double[] a) {

        if (Arrays.stream(a).anyMatch(element -> element<0))
            throw new NegativeNumberException("Имеется элемент меньше 0");

        List<Double> aList = new ArrayList<>(Arrays.stream(a)
                .boxed()
                .toList());
        Collections.reverse(aList);

        LinkedHashSet<Double> aHashSet = new LinkedHashSet<>(aList);
        aList = new ArrayList<>(aHashSet.stream().toList());
        Collections.reverse(aList);
        return aList.stream().mapToDouble(element -> element).toArray();
    }

    public static double[] taskDistinct(double[] a) {

        if (Arrays.stream(a).anyMatch(element -> element<0))
            throw new NegativeNumberException("Имеется элемент меньше 0");

        List<Double> aList = new ArrayList<>(Arrays.stream(a)
                .boxed()
                .toList());
        Collections.reverse(aList);

        aList = new ArrayList<>(aList.stream().distinct().toList());
        Collections.reverse(aList);
        return aList.stream().mapToDouble(element -> element).toArray();
    }

    static class NegativeNumberException extends RuntimeException{
        public NegativeNumberException(String message){
            super(message);
        }
    }

}