module Tests

open System
open Xunit
open InversionGame.Core

[<Fact>]
let ``Space.createDefault creates space initialized with O elements`` () =

    let expectedSpace = array2D [
        [O; O; O];
        [O; O; O]]

    let createdSpace = Space.createDefault 2 3

    Assert.Equal(expectedSpace, createdSpace);

[<Fact>]
let `` Space.invert with RowInversion inverts the state of the given row`` () =

    let targetSpace = array2D [
        [O; O; O];
        [O; X; X];
        [O; O; O]]

    let expectedSpace = array2D [
        [O; O; O];
        [X; O; O];
        [O; O; O]]
    
    let actualSpace = Space.invert targetSpace (RowInversion 1)

    Assert.Equal(expectedSpace, actualSpace);


[<Fact>]
let `` Space.invert with ColumnInversion inverts the state of the given column`` () =

    let targetSpace = array2D [
        [O; O; O];
        [O; X; X];
        [O; X; O]]

    let expectedSpace = array2D [
        [O; O; X];
        [O; X; O];
        [O; X; X]]
    
    let actualSpace = Space.invert targetSpace (ColumnInversion 2)

    Assert.Equal(expectedSpace, actualSpace);