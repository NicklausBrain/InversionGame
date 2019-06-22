namespace InversionGame.Core

type Inversion =
    | RowInversion of int
    | ColumnInversion of int

type State = X | O

module State =
    let invert (state: State) =
        match state with
        | O -> X
        | X -> O
    let defaultState = O

type Space = State[,]

module Space =

    type 'a ``[,]`` with
        member arr2d.rowsCount =
            Array2D.length1(arr2d)
        member arr2d.columnsCount =
            Array2D.length2(arr2d)

    let defaultInitializer = (fun i j -> State.defaultState)

    let create rowsCount columnsCount initializer : Space =
        Array2D.init rowsCount columnsCount initializer

    let createDefault rowsCount columnsCount : Space =
        create rowsCount columnsCount defaultInitializer

    let invert (space: Space) (inversion: Inversion) =
        match inversion with
        | RowInversion(targetRowIndex) ->
            create
                space.rowsCount
                space.columnsCount
                (fun rowIndex columnIndex ->
                    if rowIndex = targetRowIndex
                    then State.invert space.[rowIndex, columnIndex]
                    else space.[rowIndex, columnIndex])
        | ColumnInversion(targetColumnIndex) ->
            create
                space.rowsCount
                space.columnsCount
                (fun rowIndex columnIndex ->
                    if columnIndex = targetColumnIndex
                    then State.invert space.[rowIndex, columnIndex]
                    else space.[rowIndex, columnIndex])
