import React, {useState} from 'react';

let Component = (props) => {
    const [myData, setMyData] = useState({result:0});
    let onSubmit = (evt) => {
        evt.preventDefault();
        let n = parseInt(document.getElementById("nIn").value);
        let x = parseInt(document.getElementById("xIn").value);
        let newResult = (x + (n / 2)) % n;
        console.log(n);
        console.log(x);
        console.log(newResult);
        setMyData({result:newResult});
    }
    return (
        <div>
        <p className="result">Result = {myData.result}</p>
        <form>
            <label>N</label><br></br>
            <input type="number" id="nIn"></input><br></br>
            <label>X</label><br></br>
            <input type="number" id="xIn"></input><br></br>
            <button type="submit" onClick={onSubmit}>Calculate</button>
        </form>
        </div>
    );
}
export default Component;