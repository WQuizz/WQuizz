import { useState,useEffect } from "react";
import  "../Styles/patchnoteselement.css";
import { Link } from 'react-router-dom';

export default function PatchNotesElement(){

    const [patchNotes, setPatchNotes] = useState([]);

    useEffect(() => {
        fetch("https://api.github.com/repos/WQuizz/WQuizz/issues?state=closed")
        .then(res =>res.json())
        .then(json => {
           const filtered = json.filter(p=>{
                return !p.hasOwnProperty("pull_request")
             })
             setPatchNotes(filtered)
        })
        .catch((error) => console.log(error))
    }, [])

    useEffect(()=>{
    },[patchNotes])

    
    return (
      <>
        <div className="card text-white bg-dark mb-3 patch-notes">
          <div className="card-header d-flex align-items-center"></div>
          <div className="card-body-main">
            <h5 className="card-title">Recent Changes</h5>
          </div>
        </div>
        {patchNotes &&
          patchNotes
            .sort((a, b) => new Date(b["closed_at"]) - new Date(a["closed_at"]))
            .slice(0, 4)
            .map((p) => (
              <div className="card text-white bg-dark mb-3 patch-notes" key={p.id}>
                <div className="card-header names">
                  {p.assignees.map((a) => (
                    <div key={a.id}>
                      <Link to={a.html_url} target="_blank">
                        <img className="avatarcircle" src={a.avatar_url} alt="userprofile" />
                      </Link>
                      <Link to={a.html_url} target="_blank">
                        <span>{a.login}</span>
                      </Link>
                    </div>
                  ))}
                </div>
                <div className="card-body">
                  <h7 className="card-title">{p.title}</h7>
                  <p className="card-text"></p>
                </div>
              </div>
            ))}
      </>
    );
      
}