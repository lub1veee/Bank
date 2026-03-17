using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    /// <summary>
    /// Представляет простой банковский счет, поддерживающий операции пополнения (Credit) и снятия (Debit).
    /// </summary>
    /// <remarks>
    /// Этот класс демонстрирует базовые операции с банковским счетом, включая проверку корректности входных данных
    /// и генерацию исключений при нарушении бизнес-правил (например, попытка снятия суммы, превышающей баланс).
    /// </remarks>
    /// <example>
    /// Пример использования класса:
    /// <code>
    /// BankAccount account = new BankAccount("John Doe", 100.00);
    /// account.Credit(50.00); // Баланс становится 150.00
    /// account.Debit(30.00);  // Баланс становится 120.00
    /// Console.WriteLine(account.Balance);
    /// </code>
    /// </example>
    public class BankAccount
    {
        /// <summary>
        /// Сообщение об ошибке, указывающее, что сумма снятия превышает текущий баланс счета.
        /// Используется в исключении <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Сообщение об ошибке, указывающее, что сумма снятия меньше нуля.
        /// Используется в исключении <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        /// <summary>
        /// Сообщение об ошибке, указывающее, что сумма пополнения меньше нуля.
        /// Используется в исключении <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        /// <summary>
        /// Имя владельца счета. Поле только для чтения.
        /// </summary>
        private readonly string m_customerName;

        /// <summary>
        /// Текущий баланс счета. Хранится в виде числа с плавающей точкой двойной точности.
        /// </summary>
        private double m_balance;

        /// <summary>
        /// Приватный конструктор по умолчанию. Запрещает создание экземпляра класса без указания имени и начального баланса.
        /// </summary>
        private BankAccount() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"/> с указанным именем владельца и начальным балансом.
        /// </summary>
        /// <param name="customerName">Имя владельца счета. Не может быть пустым или равным null.</param>
        /// <param name="balance">Начальный баланс счета. Обычно должен быть неотрицательным.</param>
        /// <exception cref="ArgumentNullException">Возникает, если <paramref name="customerName"/> равен null или пустой строке.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Возникает, если <paramref name="balance"/> меньше нуля.</exception>
        public BankAccount(string customerName, double balance)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                throw new ArgumentNullException(nameof(customerName), "Customer name cannot be null or empty.");
            }
            if (balance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(balance), balance, "Initial balance cannot be less than zero.");
            }

            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Возвращает имя владельца счета.
        /// </summary>
        /// <value>Имя владельца счета, заданное при создании объекта.</value>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Возвращает текущий баланс счета.
        /// </summary>
        /// <value>Текущая сумма на счете.</value>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Выполняет операцию снятия средств со счета.
        /// </summary>
        /// <param name="amount">Сумма для снятия. Должна быть положительной и не превышать текущий баланс.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, если <paramref name="amount"/> меньше нуля или превышает <see cref="Balance"/>.
        /// </exception>
        /// <example>
        /// Корректное снятие средств:
        /// <code>
        /// BankAccount account = new BankAccount("John Doe", 500);
        /// account.Debit(100); // Баланс становится 400
        /// </code>
        /// </example>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        /// <summary>
        /// Выполняет операцию пополнения счета.
        /// </summary>
        /// <param name="amount">Сумма для пополнения. Должна быть положительной.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, если <paramref name="amount"/> меньше нуля.
        /// </exception>
        /// <example>
        /// Пополнение счета:
        /// <code>
        /// BankAccount account = new BankAccount("John Doe", 100);
        /// account.Credit(50); // Баланс становится 150
        /// </code>
        /// </example>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        /// <summary>
        /// Простой пример использования класса <see cref="BankAccount"/>.
        /// </summary>
        /// <remarks>
        /// Этот метод создает экземпляр счета, выполняет несколько операций и выводит результат на консоль.
        /// </remarks>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr.Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}