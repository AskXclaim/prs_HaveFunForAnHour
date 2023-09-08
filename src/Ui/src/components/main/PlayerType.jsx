
export const PlayerType = (props) => {
    return (
        <div className="select-player"><span>Select Player 1 type:</span>
            <input onChange={(event) => props.handleSelectedPlayerTypeChange(event.target.value)}
                   checked={props.selectedPlayerType==0} type="radio" value={0}
                   name="playerType"/> Computer
            <input onChange={(event) => props.handleSelectedPlayerTypeChange(event.target.value)}
                   checked={props.selectedPlayerType==1} type="radio" value={1}
                   name="playerType"/> Human
        </div>

    )
}