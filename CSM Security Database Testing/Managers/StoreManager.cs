using CSM_Database_Testing.Managers;

using CSM_Security_Database_Core.Entities;

using CSM_Security_Database_Testing.Utils;

namespace CSM_Security_Database_Testing.Managers;

/// <summary>
///     Represents a test data storing handler for <see cref="CSM_Security_Database_Core.SecurityDatabase"/> entities.
/// </summary>
public class StoreManager {

    readonly TestingStoreManager _storeManager;

    /// <summary>
    ///     Creates a new instance
    /// </summary>
    /// <param name="storeManager">
    ///     Testing data store manager.
    /// </param>
    public StoreManager(TestingStoreManager storeManager) {
        _storeManager = storeManager;
    }

    /// <summary>
    ///     Stores a <see cref="Feature"/> test object.
    /// </summary>
    /// <param name="ref">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="Feature"/>.
    /// </returns>
    public async Task<Feature> StoreFeature(Feature? @ref = null) {
        Feature feature = DraftUtils.Feature(@ref);
        feature.State = await StoreEntityState(@ref?.State);

        return await _storeManager.Store(feature);
    }

    /// <summary>
    ///     Stores a <see cref="Solution"/> test object.
    /// </summary>
    /// <param name="ref">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="Solution"/>.
    /// </returns>
    public async Task<Solution> StoreSolution(Solution? @ref = null) {
        Solution solution = DraftUtils.Solution(@ref);
        solution.State = await StoreEntityState(@ref?.State);

        return await _storeManager.Store(solution);
    }

    /// <summary>
    ///     Stores a <see cref="Permit"/> test object.
    /// </summary>
    /// <param name="ref">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="Permit"/>.
    /// </returns>
    public async Task<Permit> StorePermit(Permit? @ref = null) {
        Permit permit = DraftUtils.Permit(@ref);
        permit.State = await StoreEntityState(@ref?.State);

        if (permit.Action == null || permit.Action?.Id <= 0) {
            permit.Action = await StoreAction(permit.Action);
        }

        if (permit.Feature == null || permit.Feature?.Id <= 0)
            permit.Feature = await StoreFeature(permit.Feature);

        if (permit.Solution == null || permit.Solution?.Id <= 0)
            permit.Solution = await StoreSolution(permit.Solution);

        return await _storeManager.Store(permit);
    }

    /// <summary>
    ///     Stores a <see cref="Permit"/> test objects.
    /// </summary>
    /// <param name="refs">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="Permit"/> collection.
    /// </returns>
    public async Task<Permit[]> StorePermits(params Permit[] @refs) {
        foreach (Permit @ref in refs) {
            Permit permit = DraftUtils.Permit(@ref);
            permit.State = await StoreEntityState(@ref?.State);

            if (permit.Action == null || permit.Action?.Id <= 0)
                permit.Action = await StoreAction(permit.Action);

            if (permit.Feature == null || permit.Feature?.Id <= 0)
                permit.Feature = await StoreFeature(permit.Feature);

            if (permit.Solution == null || permit.Solution?.Id <= 0)
                permit.Solution = await StoreSolution(permit.Solution);
        }

        return await _storeManager.Store(@refs);
    }

    /// <summary>
    ///     Stores a <see cref="Profile"/> test object.
    /// </summary>
    /// <param name="ref">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="Profile"/>.
    /// </returns>
    public async Task<Profile> StoreProfile(Profile? @ref = null) {
        Profile profile = DraftUtils.Profile(@ref);
        profile.State = await StoreEntityState(@ref?.State);

        List<Permit> permitsToStore = [];
        foreach (Permit profilePermit in profile.Permits) {
            if (profilePermit.Id <= 0)
                permitsToStore.Add(profilePermit);
        }

        List<User> usersToStore = [];
        foreach (User profileUser in profile.Users) {
            if (profileUser.Id <= 0)
                usersToStore.Add(profileUser);
        }

        await StorePermits([.. permitsToStore]);
        await StoreUsers([.. usersToStore]);

        return await _storeManager.Store(profile);
    }

    /// <summary>
    ///     Stores a <see cref="User"/> test object.
    /// </summary>
    /// <param name="ref">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="User"/>.
    /// </returns>
    public async Task<User> StoreUser(User? @ref = null) {
        User user = DraftUtils.User(@ref);
        user.State = await StoreEntityState(@ref?.State);

        if (user.UserInfo.Id <= 0)
            await StoreUserInfo(user.UserInfo);

        return await _storeManager.Store(user);
    }

    /// <summary>
    ///     Stores a <see cref="User"/> test objects.
    /// </summary>
    /// <param name="refs">
    ///     Data references.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="User"/> collection.
    /// </returns>
    public async Task<User[]> StoreUsers(params User[] @refs) {
        foreach (User @ref in @refs) {
            User user = DraftUtils.User(@ref);
            user.State = await StoreEntityState(@ref?.State);

            if (user.UserInfo?.Id <= 0)
                await StoreUserInfo(user.UserInfo);


        }

        return await _storeManager.Store(@refs);
    }

    /// <summary>
    ///     Stores a <see cref="UserInfo"/> test object.
    /// </summary>
    /// <param name="ref">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="UserInfo"/>.
    /// </returns>
    public async Task<UserInfo> StoreUserInfo(UserInfo? @ref = null) {
        UserInfo userInfo = DraftUtils.UserInfo(@ref);
        userInfo.State = await StoreEntityState(@ref?.State);

        return await _storeManager.Store(userInfo);
    }

    /// <summary>
    ///     Stores a <see cref="Vendor"/> test object.
    /// </summary>
    /// <param name="ref">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="Vendor"/>.
    /// </returns>
    public async Task<Vendor> StoreVendor(Vendor? @ref = null) {
        Vendor vendor = DraftUtils.Vendor(@ref);
        vendor.State = await StoreEntityState(@ref?.State);

        List<User> usersToStore = [];
        foreach (User vendorUser in vendor.Users) {
            if (vendorUser.Id <= 0)
                usersToStore.Add(vendorUser);
        }

        await StoreUsers([.. usersToStore]);

        return await _storeManager.Store(vendor);
    }

    /// <summary>
    ///     Stores a <see cref="CSM_Security_Database_Core.Entities.Action"/> test object.
    /// </summary>
    /// <param name="ref">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="CSM_Security_Database_Core.Entities.Action"/>.
    /// </returns>
    public async Task<CSM_Security_Database_Core.Entities.Action> StoreAction(CSM_Security_Database_Core.Entities.Action? @ref = null) {
        CSM_Security_Database_Core.Entities.Action action = DraftUtils.Action(@ref);
        action.State = await StoreEntityState(@ref?.State);
        return await _storeManager.Store(action);
    }

    /// <summary>
    ///     Stores a <see cref="EntityState"/> test object.
    /// </summary>
    /// <param name="ref">
    ///     Data reference.
    /// </param>
    /// <returns>
    ///     A test data stored <see cref="EntityState"/>.
    /// </returns>
    public async Task<EntityState> StoreEntityState(EntityState? @ref = null) {
        EntityState entityState = DraftUtils.EntityState(@ref);
        return await _storeManager.Store(entityState);
    }
}
