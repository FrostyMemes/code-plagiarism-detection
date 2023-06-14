import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;
import java.util.stream.DoubleStream;
import java.util.stream.Stream;

class inter{
        public static void interfMethod(){}
}

class a extends inter {
        private b b_cl = new b();
        private c c_cl = new c();
        static int staticNum = 1;
        int Num = 2;

        public static void aStatic(){}
        public class b{
                public int bNotStatic(){return staticNum;}
                public static int bStatic(){return staticNum;}
        }

        public static class c{
                public static int cStatic(){return staticNum;}
        }
}

public class Example {
        public static void main(String[] args) {
                var a1 = new a();
                var b1 = a1.new b();
                var c1 = new a.c();
                a1.aStatic();
                b1.bStatic();
                c1.cStatic();
                a.b.bStatic();
                a.c.cStatic();
        }
}

/*
    Function<String, String> f1 = s -> s + "1";
    Function<String, String> f2 = s -> s + "2";
    Function<String, String> f3 = s -> s + "3";
    Function<String, String> f4 = s -> s + "4";
    System.out.println(f1.andThen(f2).compose(f3).compose(f4).apply("Compose"));
    System.out.println(f1.andThen(f2).andThen(f3).apply("AndThen"));
 */
