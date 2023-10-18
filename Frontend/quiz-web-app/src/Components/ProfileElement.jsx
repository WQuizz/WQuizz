import DisplayProfileImageElement from "./DisplayProfileImageElement"
export default function ProfileElement({user, canEdit}) {

    return (
        <div className="profile-container">
             <DisplayProfileImageElement profilePicture={user.profilePicture} />
             <div className="user-info"><p>Username: {user.userName}</p></div>
             <div className="user-info"><p>Display name: {user.displayName}</p></div>
             {canEdit&& <button className="edit-profile-button">Edit your profile</button>}
        </div>
    );
}