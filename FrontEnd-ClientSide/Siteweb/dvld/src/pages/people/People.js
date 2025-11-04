// import React from 'react';
//  import './People.css';


// const People = () => {
//     return (
//         <div>
//             <h1>people page  </h1>;
//         </div>
//     );
// }

// export default People;


import React from 'react';
import './People.css';

const People = () => {
    // Fake people data
    const fakePeople = [
        { id: 1, name: 'Alice Johnson', age: 28, city: 'New York', occupation: 'Designer' },
        { id: 2, name: 'Bob Smith', age: 32, city: 'Los Angeles', occupation: 'Developer' },
        { id: 3, name: 'Carol Davis', age: 25, city: 'Chicago', occupation: 'Manager' },
        { id: 4, name: 'David Wilson', age: 35, city: 'Miami', occupation: 'Analyst' },
        { id: 5, name: 'Eva Brown', age: 29, city: 'Seattle', occupation: 'Engineer' }
    ];

    return (
        <div className="people-container">
            <h1 className="people-title">People Page</h1>
            
            <div className="table-wrapper">
                <table className="people-table">
                    <thead>
                        <tr className="table-header">
                            <th>ID</th>
                            <th>Name</th>
                            <th>Age</th>
                            <th>City</th>
                            <th>Occupation</th>
                        </tr>
                    </thead>
                    <tbody>
                        {fakePeople.map(person => (
                            <tr key={person.id} className="table-row">
                                <td>{person.id}</td>
                                <td>{person.name}</td>
                                <td>{person.age}</td>
                                <td>{person.city}</td>
                                <td>{person.occupation}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default People;