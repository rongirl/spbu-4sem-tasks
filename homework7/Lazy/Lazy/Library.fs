module Lazy

type ILazy<'a> =
    abstract member Get: unit -> 'a