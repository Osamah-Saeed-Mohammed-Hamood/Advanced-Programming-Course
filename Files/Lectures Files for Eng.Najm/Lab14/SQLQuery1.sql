CREATE TABLE employees (
    id INT PRIMARY KEY IDENTITY(1,1), -- رقم تلقائي
    name NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    salary DECIMAL(18, 2) NOT NULL,
    hire_date DATE NOT NULL
);
INSERT INTO employees (name, email, salary, hire_date)
VALUES
('أحمد محمد', 'ahmed@example.com', 5000.00, '2024-01-10'),
('منى علي', 'mona@example.com', 6500.00, '2023-06-01'),
('سعيد ناصر', 'saeed@example.com', 7200.00, '2022-09-15');

select * from employees