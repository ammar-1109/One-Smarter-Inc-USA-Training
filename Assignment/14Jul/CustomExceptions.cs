using System;

namespace StationeryStoreApp
{
    class LoginFailedException : Exception
    {
        public LoginFailedException() : base("Login failed after 3 attempts.")
        {
        }

        public LoginFailedException(string message) : base(message)
        {
        }
    }

    class InvalidPriceException : Exception
    {
        public InvalidPriceException() : base("Price must be greater than 0.")
        {
        }

        public InvalidPriceException(string message) : base(message)
        {
        }
    }

    class InvalidQuantityException : Exception
    {
        public InvalidQuantityException() : base("Quantity must be greater than 0.")
        {
        }

        public InvalidQuantityException(string message) : base(message)
        {
        }
    }

    class DuplicateItemException : Exception
    {
        public DuplicateItemException() : base("An item with this Item Id already exists.")
        {
        }

        public DuplicateItemException(string message) : base(message)
        {
        }
    }

    class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base("Item not found.")
        {
        }

        public ItemNotFoundException(string message) : base(message)
        {
        }
    }

    class InsufficientStockException : Exception
    {
        public InsufficientStockException() : base("Insufficient stock for this purchase.")
        {
        }

        public InsufficientStockException(string message) : base(message)
        {
        }
    }
}
