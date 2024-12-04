# ProducerConsumer-ThreadSafety 

This repository demonstrates the Producer-Consumer problem and data inconsistency in multi-threaded applications, implemented in C#. It includes solutions with and without synchronization mechanisms to address race conditions and ensure thread safety.

---

## Problem Statement ❗

The Producer-Consumer problem is a classic synchronization problem that involves two types of processes:

1. Producers: These processes generate data and place it in a shared buffer.
2. Consumers: These processes take data from the shared buffer.

The challenge arises because both producers and consumers share access to the buffer. If not handled properly, race conditions can occur, resulting in data inconsistency.

### Key Issues:
- Race Conditions: Occurs when multiple threads access shared data concurrently without proper synchronization, leading to incorrect results.
- Data Inconsistency: Without synchronization, the producer and consumer may corrupt the shared resource by accessing it simultaneously.
- Buffer Overflow or Underflow: The producer may try to add data to a full buffer, or the consumer may attempt to consume data from an empty buffer, causing errors or delays.

---

## Solution Overview 📂

The solution demonstrates how to solve the Producer-Consumer problem using different synchronization techniques to ensure thread safety. The project consists of three parts, all implemented in C#:

### 1. RaceCondition_Problem ⚠️
This project demonstrates the Producer-Consumer problem without synchronization, leading to race conditions. In this version, both the producer and consumer try to modify the shared resource (count) concurrently, which can result in incorrect outputs.

Key concepts:
- Race Conditions caused by lack of synchronization.
- Data Inconsistency when multiple threads access shared resources without proper protection.

### 2. RaceCondition_Solution 🔒
This project demonstrates a thread-safe solution using a mutex lock to synchronize access to the shared resource. The producer and consumer both interact with a shared count variable, but only one thread can access it at a time, preventing race conditions and ensuring correct results.

Key concepts:
- Mutex Lock for mutual exclusion.
- Thread Synchronization using lock statements.
- Thread Safety to ensure consistent data.

### 3. ProducerConsumer_Application 🛠️
This project implements a more advanced version of the problem using a bounded buffer and multiple producer and consumer threads. It uses the Monitor class to synchronize access to the buffer. Producers add items to the buffer, while consumers remove items. If the buffer is full, producers wait; if it’s empty, consumers wait.

Key concepts:
- Bounded Buffer and Queue for shared data.
- Monitor.Wait() and Monitor.PulseAll() for synchronization.
- Multiple Producers and Consumers to show the scalability of the solution.
- Thread-safe Logging to track production and consumption flow.

---

## Operating System Concepts Covered 🧠

### Data Inconsistency
- Processes execute concurrently.
- CPU scheduler rapidly switches between processes.
- Cooperating processes share data, which can lead to data inconsistency if accessed concurrently.

### Producer-Consumer Problem
- A bounded-buffer problem with a shared buffer used by both producer and consumer processes.
- Ensures that:
  - The producer doesn't add data to a full buffer.
  - The consumer doesn't try to remove data from an empty buffer.

### Critical Section Problem
- A Critical Section is a part of code where shared data is accessed or modified.
- Mutual Exclusion: Ensures that no other process can enter its critical section while one process is executing.
- Progress and Bounded Waiting are essential to ensure fairness and efficiency in multi-threaded environments.

### Mutex Locks 🔐
- Mutex locks provide mutual exclusion by using atomic operations like Acquire() and Release() to protect critical sections of code from concurrent access.

---

## Conclusion 🎉

This project was a valuable part of my journey in understanding the intricacies of Operating Systems, **data inconsistency**, and **thread synchronization** in C#. By experimenting with different solutions to the **Producer-Consumer problem**, I gained a deeper appreciation for the role of synchronization in concurrent programming.
