import React from 'react';

let Component = (props) =>
{
    function mapToTr(list)
    {
        return list.map((task, i) => {
            function handleUpdateTaskPrompt(){
                let newTaskValue = prompt("What is your updated task?");
                props.handleUpdateTask(task, newTaskValue);
            }
            return (
                <tr key={i}>
                    <td><button className="btn btn-secondary" onClick={() => props.handleViewTask(task.id)}>{task.id}</button></td>
                    <td>{task.description}</td>
                    <td><button className="btn btn-primary" onClick={handleUpdateTaskPrompt}>Edit</button></td>
                    <td><button className="btn btn-danger" onClick={() => props.handleRemoveTask(task.id)}>🗑</button></td>
                </tr>);
        });
    }

    return (
        <table className="table table-striped table-dark">
            <thead className="thead">
                <tr>
                    <th>ID</th>
                    <th>Description</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
            </thead>
            <tbody>{mapToTr(props.taskList)}</tbody>
        </table>
    );
}
export default Component;