import {RpsPossibleSelectableActionEnum} from "../../enums/enums";

export const RockPaperScissorsButtons = (props) => {

    return (
        <div>
            <button className="rounded-btn"
                    onClick={() => props.handleRockPaperScissorsButtonClick(RpsPossibleSelectableActionEnum.Rock)}
            >Rock
            </button>
            <button className="rounded-btn"
                    onClick={() => props.handleRockPaperScissorsButtonClick(RpsPossibleSelectableActionEnum.Paper)}
            >Paper
            </button>
            <button className="rounded-btn"
                    onClick={() => props.handleRockPaperScissorsButtonClick(RpsPossibleSelectableActionEnum.Scissors)}>Scissors
            </button>
        </div>
    )
}