import React, {useEffect, useState} from 'react';

let Component = (props) =>
{
    const [taskList, setTaskList] = useState([]);

    useEffect(() => {
        fetch("http://localhost:8080/api/todos")
            .then(response => {
                if (response.status !== 200) {
                    return Promise.reject("todos fetch failed")
                }
                return response.json();
            })
            .then(json => setTaskList(json))
            .catch(console.log);
    }, []);

    function mapToTr(list)
    {
        return list.map((task, i) => {
            function handleUpdateTaskPrompt(){
                let newTaskValue = prompt("What is your updated task?");
                props.handleUpdateTask(task, newTaskValue);
            }
            return (
                <tr key={i}>
                    <td>{task.id}</td>
                    <td>{task.description}</td>
                    <td><button className="btn btn-primary" onClick={handleUpdateTaskPrompt}>Edit</button></td>
                    <td><button className="btn btn-danger" onClick={() => props.handleRemoveTask(task.id)}>🗑</button></td>
                </tr>);
        });
    }

    return (
        <table className="table table-striped table-dark">
            <thead className="thead-light">
                <tr>
                    <th>ID</th>
                    <th>Description</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
            </thead>
            <tbody>{mapToTr(taskList)}</tbody>
        </table>
    );
}
export default Component;