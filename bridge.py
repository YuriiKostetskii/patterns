from abc import ABC, abstractmethod


class Shape(ABC):
    """
    Абстрактний базовий клас для геометричних фігур
    """
    def __init__(self, color):
        self.color = color

    @abstractmethod
    def draw(self):
        pass


class Circle(Shape):
    """
    Реалізація кола
    """
    def __init__(self, color, x, y, radius):
        super().__init__(color)
        self.x = x
        self.y = y
        self.radius = radius

    def draw(self):
        print(f"Малюємо коло {self.color} кольору з координатами ({self.x},{self.y}) і радіусом {self.radius}")


class Square(Shape):
    """
    Реалізація квадрату
    """
    def __init__(self, color, x, y, side):
        super().__init__(color)
        self.x = x
        self.y = y
        self.side = side

    def draw(self):
        print(f"Малюємо квадрат {self.color} кольору з координатами ({self.x},{self.y}) і довжиною сторони {self.side}")


class Renderer(ABC):
    """
    Абстрактний базовий клас для рендерингу фігур
    """
    @abstractmethod
    def render_circle(self, x, y, radius, color):
        pass

    @abstractmethod
    def render_square(self, x, y, side, color):
        pass


class SVGRenderer(Renderer):
    """
    SVG-рендер
    """
    def render_circle(self, x, y, radius, color):
        print(f"Рендеримо коло {color} кольору з координатами ({x},{y}) і радіусом {radius} в SVG")

    def render_square(self, x, y, side, color):
        print(f"Рендерим квадрат {color} кольору з координатами ({x},{y}) і довжиною сторони {side} в SVG")


class CanvasRenderer(Renderer):
    """
    Реалізація рендера на канві
    """

    def render_circle(self, x, y, radius, color):
        print(f"Рендеримо коло {color} кольору з координатами ({x},{y}) і радіусом {radius} на канві")

    def render_square(self, x, y, side, color):
        print(f"Рендерим квадрат {color} кольору з координатами ({x},{y}) і довжиною сторони {side} на канві")


class ShapeRenderer:
    """
    Клас, що звязує фігури і рендер
    """
    def __init__(self, shape, renderer):
        self.shape = shape
        self.renderer = renderer

    def draw(self):
        self.shape.draw()
        if isinstance(self.renderer, SVGRenderer):
            if hasattr(self.shape,'radius'):
                self.renderer.render_circle(self.shape.x, self.shape.y, self.shape.radius, self.shape.color)
            else:
                self.renderer.render_square(self.shape.x, self.shape.y, self.shape.side, self.shape.color)
        elif isinstance(self.renderer, CanvasRenderer):
            if hasattr(self.shape, 'radius'):
                self.renderer.render_circle(self.shape.x, self.shape.y, self.shape.radius, self.shape.color)
            else:
                self.renderer.render_square(self.shape.x, self.shape.y, self.shape.side, self.shape.color)


if __name__ == "__main__":
    # створення кола і рендера
    circle = Circle("Червоного", 10, 10, 5)
    svg_renderer = SVGRenderer()

    # Створення об'єкта звязку
    circle_renderer = ShapeRenderer(circle, svg_renderer)

    # малюємо коло через SVG-рендерер
    circle_renderer.draw()

    # створення квадрату і рендера на канві
    square = Square("зеленого", 20, 20, 10)
    canvas_renderer = CanvasRenderer()

    # створення об'єкту звязку
    square_renderer = ShapeRenderer(square, canvas_renderer)

    # малюємо квадрат на канві
    square_renderer.draw()

