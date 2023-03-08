class Mediator:
    def __init__(self):
        self.users = []

    def add_user(self, user):
        self.users.append(user)

    def send_email(self, email):
        for user in self.users:
            user.receive_email(email)


class User:
    def __init__(self, name, email, mediator):
        self.name = name
        self.email = email
        self.mediator = mediator

    def send_email(self, email):
        self.mediator.send_email(email)

    def receive_email(self, email):
        print(f"{self.name} received email: {email}")


if __name__ == "__main__":
    mediator = Mediator()

    user1 = User("Alice", "alice@example.com", mediator)
    user2 = User("Bob", "bob@example.com", mediator)
    user3 = User("Charlie", "charlie@example.com", mediator)

    mediator.add_user(user1)
    mediator.add_user(user2)
    mediator.add_user(user3)

    user1.send_email("Hello, everyone!")