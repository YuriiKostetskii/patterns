from abc import ABC, abstractmethod


# Абстрактний клас творця
class Creator(ABC):
    @abstractmethod
    def factory_method(self):
        pass

    def some_operation(self):
        # викликаємо фабричний метод для роботи з продуктом
        product = self.factory_method()

        # дальше працюємо з продуктом
        result = f"Creator: Працюю с {product.operation()}"

        return result


# Конкретні креатори
class Google(Creator):
    def factory_method(self):
        return GoogleDocs()


class Microsoft(Creator):
    def factory_method(self):
        return MicrosoftWord()


# Абстрактний клас продукту
class Product(ABC):
    @abstractmethod
    def operation(self):
        pass


# Конкретні продукти
class GoogleDocs(Product):
    def operation(self):
        return "результатом роботи GoogleDocs"


class MicrosoftWord(Product):
    def operation(self):
        return "результатом роботи MicrosoftWord"


if __name__ == "__main__":
    print("Клієнт: Тестування першого креатора")
    creator = Google()
    print(creator.some_operation())

    print("\n")

    print("Клієнт: Тестування другого креатора")
    creator = Microsoft()
    print(creator.some_operation())
