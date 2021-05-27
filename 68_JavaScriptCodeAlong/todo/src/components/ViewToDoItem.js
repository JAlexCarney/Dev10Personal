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
        <form className="form-container" onSubmit={handleSubmit}>
            <label>Description</label>
            <input id="newTask" type="text" value={newTask} onChange={handleChange}></input>
            <button className="btn btn-primary" type="submit" id="btnNewTask">Add Task</button>
        </form>
    );
};
export default Component;