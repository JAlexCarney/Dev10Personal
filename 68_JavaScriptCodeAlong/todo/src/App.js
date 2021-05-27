import React, {useEffect, useState} from 'react';
import './App.css';
import ToDoList from './components/ToDoList';
import AddToDoItem from './components/AddToDoItem';
//import EditToDoItem from './components/EditToDoItem';
//import ViewToDoItem from './components/ViewToDoItem';


function App() {
  const [state, setState] = useState({list:[], currentForm: "Add"});
  useEffect(() => {
    fetch("http://localhost:8080/api/todos")
        .then(response => {
            if (response.status !== 200) {
                return Promise.reject("todos fetch failed")
            }
            return response.json();
        })
        .then(json => setState({list:json, currentForm:"Add"}))
        .catch(console.log);
  }, []);
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
      .then(json => setState({list:[...state.list, json], currentForm:state.currentForm})) // Spread new state
      .catch(console.log);
  }
  const handleRemoveTask = (id) => {
    console.log(id);
    fetch(`http://localhost:8080/api/todos/${id}`, { method: "DELETE" })
        .then(response => {
            if (response.status === 204) {
                // `filter` new state
                setState({list:state.list.filter(task => task.id !== id), currentForm:state.currentForm});
            } else if (response.status === 404) {
                return Promise.reject("sighting not found");
            } else {
                return Promise.reject(`Delete failed with status: ${response.status}`);
            }
        })
        .catch(console.log);
  }
  const handleViewTask = (task) => {

  }
  const handleUpdateTask = (task, newTaskValue) => {
    
  }
  return (
    <div className="container">
        <h1>
          Alex's ToDo Application
        </h1>
        <div className="row">
          <div className="col col-8">
            <ToDoList taskList={state.list} handleRemoveTask={handleRemoveTask} handleUpdateTask={handleUpdateTask} handleViewTask={handleViewTask}>
            </ToDoList>
          </div>
          <div className="col col-4"><AddToDoItem onNewTask={handleNewTask}></AddToDoItem></div>
        </div>
    </div>
  );
}

export default App;