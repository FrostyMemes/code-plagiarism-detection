import org.jetbrains.annotations.NotNull;

import java.util.*;
import java.util.stream.Collectors;

public class Task2 {
    public static void main(String[] args) {
        var task = new Task2();
        var result = task.getMaxMinusMinDeliveryMapByCurrency(
           new ArrayList<OrderData>(Arrays.asList(
                new OrderData (Type.DELIVERY, "EUR", 2000L),
                new OrderData (Type.DELIVERY, "USD", 15L),
                new OrderData (Type.DELIVERY, "RUB", 200L),
                new OrderData (Type.PICKUP, "RUB", 1250L),
                new OrderData (Type.DELIVERY, "USD", 35L),
                new OrderData (Type.PICKUP, "USD", 55L),
                new OrderData (Type.DELIVERY, "RUB", 100L)
           ))
        );
        System.out.println(result);
    }


   Map<String, Double> getMaxMinusMinDeliveryMapByCurrency(List<OrderData> orderDataList) {
        var deliveryOnly = orderDataList.stream()
                .filter(el -> el.getType() == Type.DELIVERY).toList();
        var currencyGroups = deliveryOnly.stream()
                .collect(Collectors.groupingBy(OrderData::getCurrency));
        var minusCurrency = new HashMap<String, Double>();

        for (var entry: currencyGroups.entrySet()) {
            var max = entry.getValue().stream()
                    .map(OrderData::getAmount)
                    .max(Long::compare).get()
                    .doubleValue();
            var min = entry.getValue().stream()
                    .map(OrderData::getAmount)
                    .min(Long::compare).get()
                    .doubleValue();
            minusCurrency.put(entry.getKey(), max-min);
        }

        return minusCurrency;
    }


    enum Type {DELIVERY, PICKUP}

    static class OrderData {
        final Type type;
        final String currency;
        final Long amount;

        OrderData(@NotNull Type type,
                  @NotNull String currency,
                  @NotNull Long amount) {
            this.type = type;
            this.currency = currency;
            this.amount = amount;
        }

        String getCurrency() {
            return currency;
        }

        Long getAmount() {
            return amount;
        }

        Type getType() {
            return type;
        }
    }
}
