# Stack & Heap

## Diagram 1 — After `Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };`

```text
STACK                              HEAP

+------------------+              +-----------------------------+
| o1               |              | Order object               |
|                  |              |                             |
| Reference ------ |------------> | OrderId = 1                |
|                  |              | CustomerName = "Ali"       |
+------------------+              | Quantity = 0                |
                                   | UnitPrice = 0               |
                                   | TotalPrice = 0              |
                                   | IsPaid = false              |
                                   | DiscountPercent = 0         |
                                   | ShippingCity = null         |
                                   | Priority = '\0'             |
                                   | ItemCode = 0                |
                                   +-----------------------------+





STACK                              HEAP

+------------------+              +-----------------------------+
| o1               |              | Order object               |
| Reference -------|----------+   |                             |
+------------------+          |   | OrderId = 1                |
                              +-> | CustomerName = "Ali"       |
+------------------+          |   | Quantity = 0                |
| o2               |          |   | UnitPrice = 0               |
| Reference -------|----------+   | TotalPrice = 0              |
+------------------+              | IsPaid = false              |
                                   | DiscountPercent = 0         |
                                   | ShippingCity = null         |
                                   | Priority = '\0'             |
                                   | ItemCode = 0                |
                                   +-----------------------------+
                                   



STACK                              HEAP

+------------------+              +-----------------------------+
| o1               |              | Order object               |
| Reference -------|----------+   |                             |
+------------------+          |   | OrderId = 1                |
                              +-> | CustomerName = "Ali"       |
+------------------+          |   | Quantity = 0                |
| o2               |          |   | UnitPrice = 0               |
| Reference -------|----------+   | TotalPrice = 0              |
+------------------+              | IsPaid = true               |
                                   | DiscountPercent = 0         |
                                   | ShippingCity = null         |
                                   | Priority = '\0'             |
                                   | ItemCode = 0                |
                                   +-----------------------------+

