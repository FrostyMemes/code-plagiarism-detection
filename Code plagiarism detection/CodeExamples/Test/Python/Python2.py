import secrets
import string


def generate_password(length=16):
   characters = string.ascii_letters + string.digits + string.punctuation
   password = "".join(secrets.choice(characters) for i in range(length))
   return password


def store_password(service, username, password):
   hashed_password = hash_function(password)


   with open("password_database.txt", "a") as f:
       f.write(f"{service},{username},{hashed_password}\n")


def get_password(service, username):

   with open("password_database.txt") as f:
       for line in f:
           service_, username_, hashed_password_ = line.strip().split(",")
           if service == service_ and username == username_:
               if hash_function(password) == hashed_password_:
                   return password
       return None