# DVLD: Driving License Management System – Project 1

## System Overview
The Driving & Vehicle License Department (DVLD) system is a comprehensive driving license management platform that handles various license-related operations and services for citizens.

## Interface Desktop  Client Side [.NET]
![alt text](<Screenshot 2025-11-04 223004.png>)
![alt text](<Screenshot 2025-07-30 001337.png>)

## Interface Web  Client Side [eact.js]
![alt text](<Screenshot 2025-11-04 223202.png>)





## Main Features

1. **New License Issuance**  
   First-time license issuance  
   *Application fee: 5 USD*

2. **License Renewal**  
   License renewal service  
   *Application fee: 5 USD*

3. **License Replacement**  
   Replacement for lost/damaged licenses  
   *Application fee: 5 USD*

4. **International License Issuance**  
   International driving license issuance  
   *Application fee: 5 USD*

5. **Replacement for Lost License**  
   Replacement for lost licenses  
   *Application fee: 5 USD*

6. **License Replacement Request**  
   License replacement applications  
   *Application fee: 5 USD*

7. **Replacement for Damaged License**  
   Replacement for damaged licenses  
   *Application fee: 5 USD*



## License Classes

The system supports 7 license classes with different requirements and fees:

| Class | Description                    | Min Age | Fee     | Validity |
|-------|--------------------------------|---------|---------|----------|
| 1     | Small Motorcycle License       | 18      | 15 USD  | 5 years  |
| 2     | Large Motorcycle License       | 21      | 30 USD  | 5 years  |
| 3     | Private Car License            | 18      | 20 USD  | 10 years |
| 4     | Truck/Bus License              | 21      | 200 USD | 10 years |
| 5     | Agricultural Vehicles          | 21      | 50 USD  | 10 years |
| 6     | Small/Medium Buses             | 21      | 250 USD | 10 years |
| 7     | Large Vehicles & Trailers      | 21      | 300 USD | 10 years |



## Application Requirements

### Required Documents

- National ID Number  
- Full Name (Arabic)  
- Date of Birth  
- Gender  
- Address  
- Phone Number  
- Email  
- Personal Photo  

### Testing Requirements

1. **Vision Test**  
   - *Fee: 10 USD*  
   - Required before license issuance  
   - Tests visual acuity and color perception  

2. **Written Test**  
   - *Fee: 20 USD*  
   - Required after vision test  
   - Tests traffic rules and regulations knowledge  
   - 100 multiple-choice questions  

3. **Practical Driving Test**  
   - *Fee: Varies by license class*  
   - Required after written test  
   - Tests actual driving skills  
   - Must pass before license issuance  



## System Management Features

1. **User Management**  
   - Add new users  
   - View user information  
   - Edit user details  
   - Delete users  
   - Manage user permissions  
   - Generate user reports  

2. **People Management**  
   - Search by national ID  
   - View person information  
   - Add new person  
   - Edit person details  
   - Delete person records *(Cannot delete person with active license)*

3. **Application Management**  
   - Search by application number  
   - Search by national ID  
   - View application status  
   - View application details  
   - Edit application information  
   - Filter applications by status  

4. **Test Management**  
   - Manage fixed tests  
   - Edit test information only  

5. **License Classes Management**  
   - Manage fixed license classes  
   - Edit class information, fees, and age requirements  

6. **License Replacement Management**  
   - Handle license replacement requests  
   - Track replacement status  
   - Manage replacement fees  



## Technical Requirements

- Maintains comprehensive records of all transactions  
- Each application must be linked to a person in the system  
- License validity and fees vary by class  
- Multiple testing phases required for license issuance  
- Supports international license issuance  
- Comprehensive reporting and tracking capabilities  



## Security & Compliance

- All applications require proper identification  
- Age verification for each license class  
- Testing compliance before license issuance  
- Audit trail for all transactions  
- Data integrity maintenance  



## Learning Note

This project is built using **Entity Framework** and **ADO.NET** for educational purposes and learning objectives.

## ==> The Client Sides not complited yet 



## License

**MIT License** — Free for educational and commercial 