import {Player} from "./Player";
import {PlayerType} from "./PlayerType";
import {ScoreCard} from "./ScoreCard";
import {useState, useEffect} from "react";
import {
    getRockPaperScissorsPlayer,
    convertSelectableActionBackToString,
    getRandomSelectableAction
} from "../../utils/helperMethods"
import {RpsPlayerTypeEnum,RpsResultEnum} from "../../enums/enums"

const getTrackeringId = () =>
    Math.random();

const getResultWordings = (player1, player2) => {
    if (!player1 || !player2)
        console.log("One or both players passed is/are invalid");

    if (player1.result === player2.result)
        return "It's a tie";

    if (player1.result === RpsResultEnum.Win)
        return `${player1.name} won!`;

    if (player2.result === RpsResultEnum.Win)
        return `${player2.name} won!`;
}
export const RockPaperScissor = () => {
    const [playerOne, setPlayerOne] = useState(getRockPaperScissorsPlayer("Player1", RpsPlayerTypeEnum.Human));
    const [playerTwo, setPlayerTwo] = useState(getRockPaperScissorsPlayer("Player2", RpsPlayerTypeEnum.Computer));
    const [tracker, setTracker] = useState(0);

    const handleSelectedPlayerTypeChange = (value) => {
        setPlayerOne({
            ...playerOne, playerType: parseInt(value)
        });
    };
    const handleRockPaperScissorsButtonClick = (selectedAction) => {
        setPlayerOne({
            ...playerOne, currentHand: selectedAction
        });

        setPlayerTwo({
            ...playerTwo, currentHand: getRandomSelectableAction()
        });

        setTracker(getTrackeringId());
    };
    const handleComputerVsComputerPlayBtn = async () => {
        setPlayerOne({
            ...playerOne, currentHand: getRandomSelectableAction()
        });
        setPlayerTwo({
            ...playerTwo, currentHand: getRandomSelectableAction()
        });
        setTracker(getTrackeringId());
    };
    const handleResetBtn = () => {
        setPlayerOne(getRockPaperScissorsPlayer("Player1", RpsPlayerTypeEnum.Human));
        setPlayerTwo(getRockPaperScissorsPlayer("Player2", RpsPlayerTypeEnum.Computer));
    };

    useEffect(() => {
        if (playerOne.currentHand === null || playerTwo.currentHand === null)
            return;

        const data = [playerOne, playerTwo];
        const playGame = async () => {
            try {
                const response = await fetch('https://localhost:7250/api/TwoPlayerRpsGame/Play', {
                    method: "POST",
                    body: JSON.stringify(data),
                    headers: {
                        "Content-Type": "application/json"
                    }
                });

                if (!response.ok) {
                    //Log the error and decided best approach
                    console.log("A possible Network error occurred, please try again later.");
                    return;
                }
                const result = await response.json();
                
                setPlayerOne(result[0]);
                setPlayerTwo(result[1]);
            } catch (error) {
                console.log(error);
                throw new Error(`The following error occurred while trying to access the api: Error:${error}`);
            }
        };

        playGame();
    }, [tracker]);

    return (
        <div className="center">
            <h1>Rock Paper Scissors</h1>
            <hr/>
            <PlayerType handleSelectedPlayerTypeChange={handleSelectedPlayerTypeChange}
                        selectedPlayerType={playerOne.playerType}/>
            <hr/>
            <button className="reset-btn" onClick={handleResetBtn}>Reset</button>
            <div className="player-container">
                <Player name="Player1"
                        score={playerOne.score}
                        selectedAction={convertSelectableActionBackToString(playerOne.currentHand)}
                        showButtons={playerOne.playerType == RpsPlayerTypeEnum.Human}
                        handleRockPaperScissorsButtonClick={handleRockPaperScissorsButtonClick}/>
                <Player name="Player2"
                        score={playerTwo.score}
                        selectedAction={convertSelectableActionBackToString(playerTwo.currentHand)}/>
            </div>
            <div>
                {playerOne.playerType == playerTwo.playerType &&
                    (<button className="rounded-btn" onClick={handleComputerVsComputerPlayBtn}>Play</button>)}
            </div>
            <hr/>
            <div className="score-card">
                <ScoreCard text={getResultWordings(playerOne, playerTwo)}/>
            </div>
            <hr/>
        </div>
    )
}