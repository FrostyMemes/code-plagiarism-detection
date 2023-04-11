import os
import sys

def main():
    folder = os.path.dirname(os.path.realpath(sys.argv[0]))
    for count, filename in enumerate(os.listdir(folder)):
        name, ext = os.path.splitext(filename)
        new_name = f"{folder}/{count}{ext}"
        old_name = f"{folder}/{filename}"
        os.rename(old_name, new_name)


if __name__ == '__main__':
    main()
