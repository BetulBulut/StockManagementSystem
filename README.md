# Stock Management System

**Stock Management System**, stok türü, birimi ve stok gibi yapıları yönetebilmeyi sağlayan arayüze sahip bir uygulamadır.

## 🔧 Kullanılan Teknolojiler

| Katman | Teknoloji |
|--------|-----------|
| Backend | ASP.NET Core 9.0 Web API |
| ORM | Entity Framework Core 9 |
| Veritabanı | Microsoft SQL Server |
| İşlem Yönetimi | Unit of Work Pattern |
| Dependency Injection | Built-in DI container |
| Diğer | Serilog, AutoMapper, FluentValidation |
| Frontend | Angular, TypeScript, Bootstrap |

---

## 📂 Proje Yapısı
StockManagementSystem 
│

├── client                        → Angular UI (Modüler yapıda)

│   └── stock-management-ui       → Angular CLI projesi (src/app/modules altında modüller)

├── server

│   ├── API                       → API Katmanı (Controller’lar, Program.cs)

│   ├── Application               → İş kuralları (Servisler, DTO’lar, Interfaces)

│   ├── Domain                    → Entity’ler ve Değer Nesneleri

│   ├── Infrastructure            → EF DbContext

---

## 🚀 Başlangıç

### 1. Gerekli Bağımlılıklar

- .NET 8 SDK
- SQL Server
- Angular CLI 
- Node.js      : 22.12.0
- npm          : 10.9.0

---

### 2. Veritabanı Ayarları

`appsettings.json` içinde aşağıdaki bağlantı dizesini kendi ortamınıza göre güncelleyin:

```json
"ConnectionStrings": {
  "SqlServer": "your-sql-connection-string"
}
```

### 3.🛠️ Migration Oluşturma ve Uygulama

```bash
cd server/Infrastructure
dotnet ef migrations add initialMigration  --output-dir .\Migrations --startup-project ..\API

cd ..
cd API
dotnet ef database update
```
## Çalıştırma

```bash
cd API
dotnet run

```

## UI

```bash
export const environment = {
  production: false,
  apiUrl: 'your-api-url'
};
```
Environment ayarlarını yapmalısın

```bash
cd client/stock-management-ui
ng serve
```

### 4. 📌 Temel Özellikler


✅ Stok türü, Stok birimi ve Stok'ların oluşturulması ve yönetilmesi

✅ Unit of Work ve Repository pattern ile Transactional Veri Erişimi

✅ EF Fluent API + Seed Data ile Sağlam DB Tasarımı

✅ Angular ile kullanışlı arayüz


### 5. UI görselleri

![1](https://github.com/user-attachments/assets/d2727c2e-4e3e-497e-990f-e23d8fcb6034)

![2](https://github.com/user-attachments/assets/4a47bcfb-aedd-4142-a942-0aceb3307c0c)

![3](https://github.com/user-attachments/assets/0d578bd8-53c2-4ac8-b564-29deed3e3e80)

![4](https://github.com/user-attachments/assets/60ce1347-dddb-45ee-99f3-c90f8b538658)

![5](https://github.com/user-attachments/assets/3c243196-20aa-46bb-b9d9-8ba1fbb1913f)

![6](https://github.com/user-attachments/assets/3ab75316-5e87-4679-b94a-156c2d346164)

![7](https://github.com/user-attachments/assets/7972b5da-d9a8-4332-8766-686936d7d494)





