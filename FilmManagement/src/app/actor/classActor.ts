
export interface IActor {
    ActorID: number;
    ActorName: string;
    Img: string;
    Gender: boolean;
    Birthday: string;
    Describe: string;
    Status: boolean;
}

// Actor class contain base infomation of  a actor
export class Actor {

    // property
    public ActorID: number;
    public ActorName: string;
    public Img: string;
    public Gender: boolean;
    public Birthday: string;
    public Describe: string;
    public Status: boolean;

    // constructor
    constructor();
    constructor(iActor?: IActor) {
        this.ActorName = iActor && iActor.ActorName || '';
        this.Img = iActor && iActor.Img || '';
        this.Gender = iActor && iActor.Gender || true;
        this.Birthday = iActor && iActor.Birthday || Date();
        this.Describe = iActor && iActor.Describe || '';
        this.Status = iActor && iActor.Status || false ;
    }
}
