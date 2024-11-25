module LazyInterface

type ILazy<'a> =
    abstract member Get: unit -> 'a