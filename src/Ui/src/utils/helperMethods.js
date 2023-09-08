import {RpsPossibleSelectableActionEnum,RpsResultEnum} from "../enums/enums";

export const getRockPaperScissorsPlayer = (name, playerTypeEnum) => {
    if (!name || typeof name !== "string")
        alert("Please supply a valid name");

    return {
        name: name,
        playerType: parseInt(playerTypeEnum),
        score: 0,
        currentHand: null,
        result: RpsResultEnum.Tie
    };
};

export const convertSelectableActionBackToString = (value) => {
    if (value === null || value === undefined)
        return "";
    if (value === RpsPossibleSelectableActionEnum.Rock)
        return "Rock";

    if (value === RpsPossibleSelectableActionEnum.Paper)
        return "Paper"

    if (value === RpsPossibleSelectableActionEnum.Scissors)
        return "Scissors"

    throw new Error("Invalid value passed in.")
};
export const getRandomSelectableAction = (upperLimit = 3) =>
    Math.floor(Math.random() * upperLimit);

   
