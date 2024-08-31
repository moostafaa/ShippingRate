**Shipping Quote Aggregator**

The Shipping Quote Aggregator is a robust C# application designed to provide real-time shipping quotes from multiple service providers. This application employs asynchronous programming to handle high-load requests efficiently and uses design patterns, specifically the Strategy and Factory patterns, to ensure clean, maintainable, and scalable code. The solution is intended for environments where multiple shipping options need to be evaluated, making it suitable for e-commerce platforms, logistics companies, or any business that relies on shipping.

**Features**
Asynchronous API Requests: Utilizes HttpClient and asynchronous programming for high performance under load, allowing hundreds of requests per minute.
Multi-provider Integration: Supports querying multiple shipping providers through well-defined interfaces, each providing a consistent method for obtaining shipping quotes.
Readability and Maintainability: Implemented using object-oriented design principles and design patterns for easy readability and maintainability.
Unit Testing: Includes unit tests to ensure the correctness of functionality and reliability when fetching and processing shipping quotes.
