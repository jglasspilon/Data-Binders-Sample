# Case Study: Data Binders

## Overview
Designed and developed a "No-code" data binder system that allows simple generic data binding of JSON data to various UGUI components.

---

## Role & Responsibilities 
- Designed the code architecture for the system
- Determined and prioritized needed components with mentality towards easy scalling 
- Built modular, data-binder components  
- Built single point of entry component for easy one line consumer implementation  

---

## Challenge
Creating data-driven graphics generally involves the hard coding of data mapped to various serialized components. This makes the creation of graphics a very programmer first approach and is not very agile. 
This also involves a growing code base to maintain as the graphics increase in scope and new graphics are created.

---

## Solution
Take an MVVM approach and create reusable components that can specify what field from a JSON payload to use and how to bind that data to various UGUI components. 
Each of these binder components would then be attached to a parent Data Binder that would feed them the JSON data provided by the graphic class. 
In this way, the graphic class only has knowledge of the parent binder to allow for the transfer of data. 
This approach abstracts out all of the graphical binding logic from the graphic class and allows for very quick modifications with zero code manipulation once implemented.

---

## Tools & Technologies
- Unity UGUI
- C#  
- JSON 
- Git version control  

---

## Outcome / Impact
Vastly improved turn-around speed for graphic modifications and changes to data binding. 
Before: days of development time with extra QA required
After: hours of implementation time with zero QA required since design/data modifications would lead to zero changes in code.  

---

## Screenshots / GIFs
Add images or short GIFs to showcase the UI work. Keep it generic to avoid proprietary content.  

## Key Learnings
- Abstracting out data binding logic vastly helps reduce code complexity and improve scalability
- "No-Code" scalable systems allow for reduced scope of QA and vastly reduces the amount of code maintenance, as well as the chances for error 
