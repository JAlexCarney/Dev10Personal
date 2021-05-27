import React, {useState} from 'react';
import './App.css';
import ToDoList from './components/ToDoList';
import AddToDoItem from './components/AddToDoItem';


function App() {
  const [taskList, setTaskList] = useState(0);
  const handleNewTask = (task) => {
    const init = {
      method: "POST",
      headers: {
          "Content-Type": "application/json",
          "Accept": "application/json"
      },
      body: JSON.stringify(task)
    };

    fetch("http://localhost:8080/api/todos", init)
      .then(response => {
          if (response.status !== 201) {
              return Promise.reject("response is not 200 OK");
          }
          return response.json();
      })
      .then(json => setTaskList(json)) // Spread new state
      .catch(console.log);
  }
  const handleRemoveTask = (id) => {
    console.log(id);
    fetch(`http://localhost:8080/api/todos/${id}`, { method: "DELETE" })
        .then(response => {
            if (response.status === 204) {
                // `filter` new state
                setTaskList(taskList.filter(task => task.id !== id));
            } else if (response.status === 404) {
                return Promise.reject("sighting not found");
            } else {
                return Promise.reject(`Delete failed with status: ${response.status}`);
            }
        })
        .catch(console.log);
  }
  const handleUpdateTask = (task, newTaskValue) => {
    
  }
  return (
    <div className="App">
      <header className="App-header">
        <h1>
          Alex's ToDo Application
        </h1>
        <div className="row">
          <div className="col col-8"><ToDoList handleRemoveTask={handleRemoveTask} handleUpdateTask={handleUpdateTask}></ToDoList></div>
          <div className="col col-4"><AddToDoItem onNewTask={handleNewTask}></AddToDoItem></div>
        </div>
      </header>
    </div>
  );
}

export default App;