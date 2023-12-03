
[Обратно към ReadMe](/README.md)

# `POST /api/client_order/create`
Екшън, който създрава поръчка, на база избраните части и тяхното количество от клиент.

## Request
 Приема параметър от тялото на заявката в JSON формат със следната структура:

- `id`: Уникален идентификатор на клиента, направил поръчката.
- `description`: Описание, въведено от клиента за допълнителна информация. Полето е опционно.
- `quantity`: Количество на поръчката. Отразява се за всяка една част.
- `vatId`: ДДС за определената държава.
- `parts`: Списък от поръчани части.
- `partId`: Идентификационнен номер на поръчаната част.    

### Example:
 Body request:

```json
{
  "id": "17ce735d-6713-4d0a-8fcb-e4a71ee86f6f",
  "description": "string",
  "quantity": 1,
  "vatId": 1,
  "parts": [
    {
      "partId": 1
    },
    {
      "partId": 3
    },
    {
      "partId": 4
    }
  ]
}
```
## Response
При валидни данни и успешно записване на записите в базата данни контролера връща JSON обект със следната структура:

- `orderId`: Уникален идентификатор на направената поръчка.
- `clientId`: Уникален идентификатор на клиента, направил поръчката.
- `description`: Описание, въведено от клиента за допълнителна информация. Полето е опционно.
- `saleAmount`: Данъчна основа на поръчката.
- `discount`: Намаление на поръчката.
- `vat`: Сума на ДДС на поръчката.
- `finalAmount`: Крайна сума на поръчката.
- `paidAmount`: Платена сума.
- `unpaidAmount`: Остатък за плащане.
- `parts`: Колекция от поръчаните частите.
- `name`: Име на часта. 
- `quantity`: Количество на поръчаната част.
- `partId`: Идентификационнен номер на поръчаната част.
- `price`: Сума на частите.
### Example:
```json
{
    "orderId": 70,
    "clientId": "17ce735d-6713-4d0a-8fcb-e4a71ee86f6f",
    "description": "fgdfg",
    "saleAmount": 195.84,
    "discount": 20.00,
    "vat": 39.16,
    "finalAmount": 235.00,
    "paidAmount": 0,
    "unpaidAmount": 0,
    "parts": [
        {
            "name": "Frame Road",
            "quantity": 1,
            "partId": 1,
            "price": 80.00
        },
        {
            "name": "Frame Road woman",
            "quantity": 1,
            "partId": 3,
            "price": 80.00
        },
        {
            "name": "Wheel of the Year for road",
            "quantity": 1,
            "partId": 4,
            "price": 75.00
        }
    ]
}
```

[Обратно към ReadMe](/README.md)