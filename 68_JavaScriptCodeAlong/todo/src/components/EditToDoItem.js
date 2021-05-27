import React, {useState} from 'react';

let Component = (props) =>
{
    const [newTask, setNewTask] = useState("");
    const handleChange = function(event){
        setNewTask(event.target.value);
    }
    const handleSubmit = function(event){
        event.preventDefault();
        const task = {
            "description": newTask,  
        };
        props.onNewTask(task);
        setNewTask("");
    }
    return (
        <form onSubmit={handleSubmit}>
            <h3>Editing Task</h3>
            <label>Description</label>
            <input id="newTask" type="text" value={props.description} onChange={handleChange}></input>
            <button className="btn btn-primary" type="submit" id="btnNewTask">Add Task</button>
        </form>
    );
};
export default Component;