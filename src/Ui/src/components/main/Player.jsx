import {RockPaperScissorsButtons} from "../main/RockPaperScissorsButtons";

export const Player = (
    {
        name,
        score,
        selectedAction,
        showButtons,
        handleRockPaperScissorsButtonClick
    }) => {

    return (
        <div>
            <div className="player">
                <div className="player-name-score">{name} : {score}</div>
                <div className="selected-option">{selectedAction}</div>
            </div>
            {showButtons && (
                <RockPaperScissorsButtons handleRockPaperScissorsButtonClick={handleRockPaperScissorsButtonClick}/>
            )}
        </div>

    )
}