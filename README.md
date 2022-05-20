# TAI_Bakery_API

## Configuration
1. Clone or download repository
2. Open solution in Visual Studio
3. Right-click on project and choose "Manage user secrets"
4. In secrets.json put connection string to your Postgres database, for example:
```
{
  "TAI_Bakery": {
    "ConnectionString": "Server=localhost;Port=5432;Database=TAI_Bakery;User Id=postgres;Password=password;"
  }
}
```
5. Open NuGet Manager console and type:
```
Update-Database
```

## Endpoints - Categories
<table>
  <tr>
    <td>Http Method</td>
    <td>Http Endpoint</td>
    <td>Description</td>
    <td>Example data</td>
  </tr>
  <tr>
    <td>GET</td>
    <td><pre>/api/categories/all</pre></td>
    <td>Returns all categories</td>
    <td>
<pre>
[
  {
    "categoryId": 1,
    "categoryName": "Torty"
  },
  {
    "categoryId": 2,
    "categoryName": "Ciasta"
  },
  {
    "categoryId": 3,
    "categoryName": "Ciastka"
  }
]
</pre>
    </td>
  </tr>
  <tr>
    <td>GET</td>
    <td><pre>/api/categories/{id}</pre></td>
    <td>Returns category by ID</td>
    <td>
<pre>
{
  "categoryId": 2,
  "categoryName": "Ciasta"
}
</pre>
    </td>
  </tr>
  <tr>
    <td>POST</td>
    <td><pre>/api/categories/add</pre></td>
    <td>Adds a new category</td>
    <td>
<pre>
{
  "categoryName": "Pieczywo"
}
</pre>
    </td>
  </tr>
  <tr>
    <td>PUT</td>
    <td><pre>/api/categories/update</pre></td>
    <td>Updates an existing category</td>
    <td>
<pre>
{
  "categoryId": 2,
  "categoryName": "Napoje"
}
</pre>
    </td>
  </tr>
  <tr>
      <td>DELETE</td>
    <td><pre>/api/categories/delete/{id}</pre></td>
    <td>Deletes a category by ID</td>
    <td>
<pre>
</pre>
    </td>
  </tr>
</table>

## Endpoints - Products
<table>
  <tr>
    <td>Http Method</td>
    <td>Http Endpoint</td>
    <td>Description</td>
    <td>Example data</td>
  </tr>
  <tr>
    <td>GET</td>
    <td><pre>/api/products/all</pre></td>
    <td>Returns all products</td>
    <td>
<pre>
[
  {
    "productId": 1,
    "categoryId": 1,
    "name": "Tort własny",
    "description": "Sam skomponuj swój wymarzony tort!",
    "price": 50,
    "isByWeight": false,
    "isCustomizable": true,
    "imageUrl": "tort.png",
    "category": {
      "categoryId": 1,
      "categoryName": "Torty"
    }
  },
  {
    "productId": 2,
    "categoryId": 2,
    "name": "Brownie",
    "description": "Pyszne czekoladowe ciasto",
    "price": 20,
    "isByWeight": false,
    "isCustomizable": false,
    "imageUrl": "brownie.png",
    "category": {
      "categoryId": 2,
      "categoryName": "Ciasta"
    }
  }
]
</pre>
    </td>
  </tr>
  <tr>
    <td>GET</td>
    <td><pre>/api/products/{id}</pre></td>
    <td>Returns product by ID</td>
    <td>
<pre>
{
  "productId": 2,
  "categoryId": 2,
  "name": "Brownie",
  "description": "Pyszne czekoladowe ciasto",
  "price": 20,
  "isByWeight": false,
  "isCustomizable": false,
  "imageUrl": "brownie.png",
  "category": {
    "categoryId": 2,
    "categoryName": "Ciasta"
  }
}
</pre>
    </td>
  </tr>
    </tr>
  <tr>
    <td>GET</td>
    <td><pre>/api/products?categoryId={id}}</pre></td>
    <td>Returns products by category ID</td>
    <td>
<pre>
{
  "productId": 2,
  "categoryId": 2,
  "name": "Brownie",
  "description": "Pyszne czekoladowe ciasto",
  "price": 20,
  "isByWeight": false,
  "isCustomizable": false,
  "imageUrl": "brownie.png",
  "category": {
    "categoryId": 2,
    "categoryName": "Ciasta"
  }
}
</pre>
    </td>
  </tr>
  <tr>
    <td>POST</td>
    <td><pre>/api/product/add</pre></td>
    <td>Adds a new product</td>
    <td>
<pre>
{
  "categoryId": 2,
  "name": "Kremówka",
  "description": "Ciasto z kremem",
  "price": 20,
  "isByWeight": false,
  "isCustomizable": false,
  "imageUrl": "kremowka.png"
}
</pre>
    </td>
  </tr>
  <tr>
    <td>PUT</td>
    <td><pre>/api/products/update</pre></td>
    <td>Updates an existing product</td>
    <td>
<pre>
{
  "productId": 2,
  "categoryId": 2,
  "name": "Brownie",
  "description": "Pyszne czekoladowe ciasto",
  "price": 20,
  "isByWeight": false,
  "isCustomizable": false,
  "imageUrl": "brownie.png"
}
</pre>
    </td>
  </tr>
  <tr>
      <td>DELETE</td>
    <td><pre>/api/products/delete/{id}</pre></td>
    <td>Deletes a product by ID</td>
    <td>
<pre>
</pre>
    </td>
  </tr>
</table>

## Endpoints - Orders
<table>
  <tr>
    <td>Http Method</td>
    <td>Http Endpoint</td>
    <td>Description</td>
    <td>Example data</td>
  </tr>
  <tr>
    <td>GET</td>
    <td><pre>/api/orders/all</pre></td>
    <td>Returns all orders</td>
    <td>
<pre>
[
  {
    "orderId": 1,
    "customerEmail": "piotrek@onet.pl",
    "customerName": "Piotr Kowalski",
    "customerPhone": "+48501215489",
    "customerAddress": "Aleja Jana Pawła II 100",
    "customerCity": "",
    "customerPostalCode": "00-213",
    "date": "2022-05-19T21:02:46.751567",
    "deliveryDate": "2022-05-21T21:02:46.751567",
    "orderValue": 50,
    "isFinished": false,
    "orderDetails": null
  },
  {
    "orderId": 2,
    "customerEmail": "jan.kowalski@gmail.com",
    "customerName": "Jan Kowalski",
    "customerPhone": "+48501355704",
    "customerAddress": "Długa 10",
    "customerCity": "",
    "customerPostalCode": "02-137",
    "date": "2022-05-19T21:02:46.751568",
    "deliveryDate": "2022-05-23T21:02:46.751568",
    "orderValue": 20,
    "isFinished": false,
    "orderDetails": null
  }
]
</pre>
    </td>
  </tr>
  <tr>
    <td>GET</td>
    <td><pre>/api/orders/{id}</pre></td>
    <td>Returns order details by order ID</td>
    <td>
<pre>
{
  "orderId": 1,
  "customerEmail": "piotrek@onet.pl",
  "customerName": "Piotr Kowalski",
  "customerPhone": "+48501215489",
  "customerAddress": "Aleja Jana Pawła II 100",
  "customerCity": "",
  "customerPostalCode": "00-213",
  "date": "2022-05-19T21:02:46.751567",
  "deliveryDate": "2022-05-21T21:02:46.751567",
  "orderValue": 50,
  "isFinished": false,
  "orderDetails": [
    {
      "orderDetailId": 1,
      "orderId": 1,
      "productId": 1,
      "quantity": 0.5,
      "price": 8.5,
      "customizationId": 1,
      "product": {
        "productId": 1,
        "categoryId": 1,
        "name": "Tort własny",
        "description": "Sam skomponuj swój wymarzony tort!",
        "price": 50,
        "isByWeight": false,
        "isCustomizable": true,
        "imageUrl": "",
        "category": null
      },
      "customization": {
        "customizationId": 1,
        "sizeId": 3,
        "glazeId": 1,
        "fillingId": 2,
        "cakeId": 1,
        "additionId": 1,
        "text": "100 lat!",
        "size": {
          "sizeId": 3,
          "diameter": 45
        },
        "glaze": {
          "glazeId": 1,
          "glazeName": "Śmietankowa",
          "glazeColor": "#FFFFF0"
        },
        "filling": {
          "fillingId": 2,
          "fillingName": "Czekoladowe",
          "fillingColor": "#7B3F00"
        },
        "cake": {
          "cakeId": 1,
          "cakeName": "Śmietankowe",
          "cakeColor": "#FFFF99"
        },
        "addition": {
          "additionId": 1,
          "additionName": "Owoce",
          "additionVisual": ""
        }
      }
    },
    {
      "orderDetailId": 2,
      "orderId": 1,
      "productId": 3,
      "quantity": 2,
      "price": 40,
      "customizationId": null,
      "product": {
        "productId": 3,
        "categoryId": 4,
        "name": "Szarlotka",
        "description": "Klasyczne ciasto ze świeżymi jabłkami",
        "price": 15,
        "isByWeight": false,
        "isCustomizable": false,
        "imageUrl": "",
        "category": null
      },
      "customization": null
    }
  ]
}
</pre>
    </td>
  </tr>
  <tr>
    <td>POST</td>
    <td><pre>/api/orders/add</pre></td>
    <td>Adds a new order</td>
    <td>
<pre>
{
  "customerEmail": "jan.kowalski@gmail.com",
  "customerName": "Jan Kowalski",
  "customerPhone": "123456789",
  "customerAddress": "Jana Pawła II 21",
  "customerCity": "Warszawa",
  "customerPostalCode": "02-137",
  "date": "2022-05-19T17:49:25.108Z",
  "deliveryDate": "2022-05-19T17:49:25.108Z",
  "orderDetails": [
    {
      "productId": 1,
      "quantity": 1,
      "customization": {
        "sizeId": 3,
        "glazeId": 1,
        "fillingId": 2,
        "cakeId": 1,
        "additionId": 1,
        "text": "100 lat!"
      }
    },
    {
      "productId": 2,
      "quantity": 3
    },
    {
      "productId": 3,
      "quantity": 2
    }
  ]
}
</pre>
    </td>
  </tr>
  <tr>
      <td>DELETE</td>
    <td><pre>/api/orders/delete/{id}</pre></td>
    <td>Deletes an order by ID</td>
    <td>
<pre>
</pre>
    </td>
  </tr>
</table>
